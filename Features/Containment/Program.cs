﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
namespace ODataSamples.Features.Containment
{
    using Microsoft.OData.Core;
    using Microsoft.OData.Core.UriParser;
    using Microsoft.OData.Core.UriParser.Semantic;
    using Microsoft.OData.Edm;
    using Microsoft.OData.Edm.Library;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    class Program
    {
        public const string DefaultNamespace = "ODataSamples.Features.EnumType";
        public static readonly Uri ServiceRootUri = new Uri("http://samples.odata.org/sample/");
        static void Main(string[] args)
        {
            Stream stream = new NonClosingStream();

            // Create a model with Enum
            // CSDL:
            // <edmx:Edmx Version="4.0" xmlns:edmx="http:// docs.oasis-open.org/odata/ns/edmx">
            //   <edmx:DataServices>
            //     <Schema Namespace="ODataSamples.Features.EnumType" xmlns="http:// docs.oasis-open.org/odata/ns/edm">
            //       <EntityType Name="Customer">
            //         <Key>
            //           <PropertyRef Name="Id" />
            //         </Key>
            //         <Property Name="Id" Type="Edm.Int32" Nullable="false" />
            //         <NavigationProperty Name="ShoppingCart" Type="Collection(ODataSamples.Features.EnumType.Product)" ContainsTarget="true" />
            //       </EntityType>
            //       <EntityType Name="Product">
            //         <Key>
            //           <PropertyRef Name="ProductID" />
            //         </Key>
            //         <Property Name="ProductID" Type="Edm.Int32" Nullable="false" />
            //       </EntityType>
            //       <EntityContainer Name="DefaultContainer">
            //         <EntitySet Name="Customers" EntityType="ODataSamples.Features.EnumType.Customer" />
            //       </EntityContainer>
            //     </Schema>
            //   </edmx:DataServices>
            // </edmx:Edmx>
            IEdmModel model = BuildEdmModel();

            // Parse the URI of contaiment
            Uri queryUri = new Uri(ServiceRootUri, "Customers(1)/ShoppingCart");
            ODataPath queryPath = ParsePath(model, queryUri);
            NavigationPropertySegment containedSegment = queryPath.LastSegment as NavigationPropertySegment;
            Console.WriteLine("The NavigationSource of ContainedSegment is {0}", containedSegment.NavigationSource.GetType().Name); // EdmContainedEntitySet

            // Write OData feed to the stream
            // JSON Light payload:
            // {
            //     "@odata.context": "http://samples.odata.org/sample/$metadata#Customers(1)/ShoppingCart",
            //     "value": [
            //         {
            //             "@odata.type": "#ODataSamples.Features.EnumType.Product",
            //             "@odata.id": "Customers(1)/ShoppingCart(1)",
            //             "@odata.editLink": "Customers(1)/ShoppingCart(1)",
            //             "ProductID": 1
            //         }
            //     ]
            // }
            WriteODataFeed(model, stream, containedSegment, queryPath);

            // Read the OData feed from stream
            stream.Seek(0, SeekOrigin.Begin);

            foreach (var entry in ReadODataFeed(model, stream))
            {
                Console.WriteLine(entry.Id);
            }
        }

        public static IEdmModel BuildEdmModel()
        {
            EdmModel model = new EdmModel();

            var defaultContainer = new EdmEntityContainer(DefaultNamespace, "DefaultContainer");
            model.AddElement(defaultContainer);

            //  Define EdmType Custumer
            var custumerType = new EdmEntityType(DefaultNamespace, "Customer");
            var customerIdProperty = new EdmStructuralProperty(custumerType, "Id", EdmCoreModel.Instance.GetInt32(false));
            custumerType.AddProperty(customerIdProperty);
            custumerType.AddKeys(new IEdmStructuralProperty[] { customerIdProperty });
            model.AddElement(custumerType);

            //  Define EdmType Product
            var productType = new EdmEntityType(DefaultNamespace, "Product");
            var productIdProperty = new EdmStructuralProperty(productType, "ProductID", EdmCoreModel.Instance.GetInt32(false));
            productType.AddProperty(productIdProperty);
            productType.AddKeys(productIdProperty);
            model.AddElement(productType);

            //  Add the Edm Entity Set Customers to container
            var customerSet = new EdmEntitySet(defaultContainer, "Customers", custumerType);
            defaultContainer.AddElement(customerSet);

            //  Add the Containment Navigation Property "ShoppingCart" to Product
            var shoppingCartNavigation = custumerType.AddUnidirectionalNavigation(new EdmNavigationPropertyInfo
            {
                Name = "ShoppingCart",
                Target = productType,
                TargetMultiplicity = EdmMultiplicity.Many,
                ContainsTarget = true
            });

            return model;
        }

        public static ODataPath ParsePath(IEdmModel model, Uri uri)
        {
            ODataUriParser uriParser = new ODataUriParser(model, ServiceRootUri, uri);
            return uriParser.ParsePath();
        }

        public static void WriteODataFeed(IEdmModel model, Stream stream, NavigationPropertySegment containedSegment, ODataPath queryPath)
        {
            // Create a ODataEntry
            ODataEntry[] entries = new ODataEntry[]
            {
                new ODataEntry()
                {
                    Properties = new[]
                    {
                        new ODataProperty {Name = "ProductID", Value = 1},
                    },
                }
            };

            var message = new ODataResponseMessage(stream);

            ODataMessageWriterSettings writerSettings = new ODataMessageWriterSettings();
            writerSettings.ODataUri = new ODataUri() { ServiceRoot = ServiceRootUri };
            writerSettings.PayloadBaseUri = ServiceRootUri;
            writerSettings.SetContentType("application/json;odata.metadata=full", Encoding.UTF8.WebName);
            writerSettings.AutoComputePayloadMetadataInJson = true;

            writerSettings.ODataUri = new ODataUri()
            {
                ServiceRoot = ServiceRootUri,
                Path = queryPath,
            };

            using (var messageWriter = new ODataMessageWriter(message, writerSettings, model))
            {
                var feedWriter = messageWriter.CreateODataFeedWriter(containedSegment.NavigationSource as IEdmEntitySetBase, containedSegment.NavigationSource.EntityType());
                var feed = new ODataFeed();

                feedWriter.WriteStart(feed);

                foreach (ODataEntry entry in entries)
                {
                    feedWriter.WriteStart(entry);
                    feedWriter.WriteEnd();
                }

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
