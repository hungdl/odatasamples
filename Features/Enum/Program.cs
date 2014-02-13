// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
namespace ODataSamples.Features.EnumType
{
    using Microsoft.OData.Core;
    using Microsoft.OData.Edm;
    using Microsoft.OData.Edm.Library;
    using Microsoft.OData.Edm.Library.Values;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EnumSample
    {
        public const string DefaultNamespace = "ODataSamples.Features.EnumType";
        public static readonly Uri ServiceRootUri = new Uri("http://samples.odata.org/sample/");

        static void Main(string[] args)
        {
            Stream stream = new NonClosingStream();

            // Create a model with Enum
            // CSDL:
            // <?xml version="1.0" encoding="utf-8"?>
            // <edmx:Edmx Version="3.0" xmlns:edmx="http:// schemas.microsoft.com/ado/2009/11/edmx">
            //   <edmx:DataServices>
            //     <Schema Namespace="ODataEnumTypeSample" xmlns="http:// schemas.microsoft.com/ado/2009/11/edm">
            //       <EnumType Name="Color">
            //         <Member Name="Red" Value="1" />
            //         <Member Name="Green" Value="2" />
            //         <Member Name="Blue" Value="4" />
            //       </EnumType>
            //       <EnumType Name="AccessLevel" IsFlags="true">
            //         <Member Name="None" Value="0" />
            //         <Member Name="Read" Value="1" />
            //         <Member Name="Write" Value="2" />
            //         <Member Name="Execute" Value="4" />
            //         <Member Name="ReadWrite" Value="3" />
            //       </EnumType>
            //       <EntityType Name="Product">
            //         <Key>
            //           <PropertyRef Name="ProductId" />
            //         </Key>
            //         <Property Name="ProductId" Type="Edm.Int32" Nullable="false" />
            //         <Property Name="Name" Type="Edm.String" Nullable="false" />
            //         <Property Name="UserAccess" Type="ODataEnumTypeSample.AccessLevel" />
            //         <Property Name="SkinColor" Type="ODataEnumTypeSample.Color" />
            //       </EntityType>
            //       <EntityContainer Name="DefaultContainer">
            //         <EntitySet Name="Products" EntityType="ODataEnumTypeSample.Product" />
            //       </EntityContainer>
            //     </Schema>
            //   </edmx:DataServices>
            // </edmx:Edmx>
            IEdmModel model = BuildEdmModel();

            // Write OData feed to the stream
            // JSON Light payload:
            // {
            //     "@odata.context": "http://samples.odata.org/sample/$metadata#Products",
            //     "value": [
            //         {
            //             "@odata.id": "Products(100)",
            //             "@odata.editLink": "Products(100)",
            //             "ProductId": 100,
            //             "Name": "The World",
            //             "SkinColor@odata.type": "#ODataSamples.Features.EnumType.Color",
            //             "SkinColor": "Green",
            //             "UserAccess@odata.type": "#ODataSamples.Features.EnumType.AccessLevel",
            //             "UserAccess": "ReadWrite, Execute"
            //         }
            //     ]
            // }
            WriteODataFeed(model, stream);

            // Read the OData feed from stream
            stream.Seek(0, SeekOrigin.Begin);

            foreach (var entry in ReadODataFeed(model, stream))
            {
                ODataEnumValue skinColor = (ODataEnumValue)entry.Properties.Single(p => p.Name == "SkinColor").Value;
                ODataEnumValue userAccess = (ODataEnumValue)entry.Properties.Single(p => p.Name == "UserAccess").Value;

                Console.WriteLine("SkinColor=" + skinColor.Value);
                Console.WriteLine("UserAccess=" + userAccess.Value);

                if (skinColor.Value != "Green" || userAccess.Value != "ReadWrite, Execute")
                {
                    throw new Exception("The Enum properties read from the response is not correct");
                }
            }
        }

        public static IEdmModel BuildEdmModel()
        {
            EdmModel model = new EdmModel();

            var defaultContainer = new EdmEntityContainer(DefaultNamespace, "DefaultContainer");
            model.AddElement(defaultContainer);

            //  Create an Enum type.
            var colorType = new EdmEnumType(DefaultNamespace, "Color", isFlags: false);
            colorType.AddMember("Red", new EdmIntegerConstant(1));
            colorType.AddMember("Green", new EdmIntegerConstant(2));
            colorType.AddMember("Blue", new EdmIntegerConstant(4));
            model.AddElement(colorType);

            //  Create another Enum type with isFlage=true.
            var accessLevelType = new EdmEnumType(DefaultNamespace, "AccessLevel", isFlags: true);
            accessLevelType.AddMember("None", new EdmIntegerConstant(0));
            accessLevelType.AddMember("Read", new EdmIntegerConstant(1));
            accessLevelType.AddMember("Write", new EdmIntegerConstant(2));
            accessLevelType.AddMember("Execute", new EdmIntegerConstant(4));
            accessLevelType.AddMember("ReadWrite", new EdmIntegerConstant(3));
            model.AddElement(accessLevelType);

            //  Create an Entity type which contains Enum properties.
            var productType = new EdmEntityType(DefaultNamespace, "Product");
            var ProductIdProperty = new EdmStructuralProperty(productType, "ProductId", EdmCoreModel.Instance.GetInt32(false));
            productType.AddProperty(ProductIdProperty);
            productType.AddKeys(ProductIdProperty);
            productType.AddProperty(new EdmStructuralProperty(productType, "Name", EdmCoreModel.Instance.GetString(false)));
            productType.AddProperty(new EdmStructuralProperty(productType, "UserAccess", new EdmEnumTypeReference(accessLevelType, true)));
            productType.AddProperty(new EdmStructuralProperty(productType, "SkinColor", new EdmEnumTypeReference(colorType, true)));
            model.AddElement(productType);

            var productSet = new EdmEntitySet(defaultContainer, "Products", productType);
            defaultContainer.AddElement(productSet);

            return model;
        }

        public static void WriteODataFeed(IEdmModel model, Stream stream)
        {
            // Create a ODataEntry
            var entry = new ODataEntry()
            {
                Properties = new List<ODataProperty>()
                {
                    new ODataProperty
                    {
                        Name = "ProductId", Value = 100
                    },
                    new ODataProperty
                    {
                        Name = "Name", Value = "The World"
                    },
                    new ODataProperty
                    {
                        Name = "SkinColor", Value = new ODataEnumValue("Green", DefaultNamespace + ".Color")
                    },
                    new ODataProperty
                    {
                        Name = "UserAccess", Value = new ODataEnumValue("ReadWrite, Execute", DefaultNamespace + ".AccessLevel")
                    }
                }
            };

            ODataMessageWriterSettings writerSettings = new ODataMessageWriterSettings();
            writerSettings.ODataUri = new ODataUri() { ServiceRoot = ServiceRootUri };
            writerSettings.PayloadBaseUri = ServiceRootUri;
            writerSettings.SetContentType("application/json;odata.metadata=full", Encoding.UTF8.WebName);
            writerSettings.AutoComputePayloadMetadataInJson = true;

            var responseMessage = new ODataResponseMessage(stream);
            using (var messageWriter = new ODataMessageWriter(responseMessage, writerSettings, model))
            {
                IEdmEntitySet entitySet = model.FindDeclaredEntitySet("Products");
                ODataWriter feedWriter = messageWriter.CreateODataFeedWriter(entitySet);

                var feed = new ODataFeed { Id = new Uri(ServiceRootUri, "Products") };
                feedWriter.WriteStart(feed);
                feedWriter.WriteStart(entry);
                feedWriter.WriteEnd();
                feedWriter.WriteEnd();
                feedWriter.Flush();
            }
        }

        public static IEnumerable<ODataEntry> ReadODataFeed(IEdmModel model, Stream stream)
        {
            ODataMessageReaderSettings readerSettings = new ODataMessageReaderSettings() { BaseUri = ServiceRootUri };
            var responseMessage = new ODataResponseMessage(stream);

            using (var messageReader = new ODataMessageReader(responseMessage, readerSettings, model))
            {
                List<ODataEntry> entries = new List<ODataEntry>();
                var reader = messageReader.CreateODataFeedReader();

                while (reader.Read())
                {
                    switch (reader.State)
                    {
                        case ODataReaderState.EntryEnd:
                            ODataEntry entry = reader.Item as ODataEntry;
                            entries.Add(entry);
                            yield return entry;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
