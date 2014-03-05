// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
namespace ODataSamples.Features.Singleton
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Microsoft.OData.Core;
    using Microsoft.OData.Core.UriParser;
    using Microsoft.OData.Core.UriParser.Semantic;
    using Microsoft.OData.Edm;
    using Microsoft.OData.Edm.Library;

    internal class Program
    {
        public const string DefaultNamespace = "ODataSamples.Features.Singleton";
        public static readonly Uri ServiceRootUri = new Uri("http://samples.odata.org/sample/");

        private static void Main(string[] args)
        {
            Stream stream = new NonClosingStream();

            //Create a model with singleton
            //CSDL:
            //<Schema Namespace="ODataSamples.Features.Singleton" xmlns="http://docs.oasis-open.org/odata/ns/edm">
            //  <EntityType Name="Company">
            //      <Key>
            //          <PropertyRef Name="CompanyID" /> 
            //      </Key>
            //      <Property Name="CompanyID" Type="Edm.Int32" Nullable="false" /> 
            //      <Property Name="Name" Type="Edm.String" /> 
            //      <Property Name="EmployeesCount" Type="Edm.Int32" /> 
            //  </EntityType>
            // <EntityContainer Name="DefaultContainer">
            //      <Singleton Name="Company" Type="ODataSamples.Features.Singleton.Company" /> 
            // </EntityContainer>
            //</Schema>
            EdmModel model = BuildEdmModel();

            // Parse the URI of singleton
            Uri queryUri = new Uri(ServiceRootUri, "Company");
            ODataPath queryPath = ParsePath(model, queryUri);
            SingletonSegment singletonSegment = queryPath.LastSegment as SingletonSegment;

            //Write singleton payload to stream
            //Json Light payload:
            //{
            //      "@odata.context":"http://samples.odata.org/sample/$metadata#Company",
            //      "@odata.id":"Company",
            //      "@odata.editLink":"Company",
            //      "CompanyID":1,
            //      "Name":"Wonderland",
            //      "EmployeesCount":1000
            //}
            WriteODataEntry(model, stream, singletonSegment, queryPath);

            stream.Seek(0, SeekOrigin.Begin);

            // Read singleton from stream
            var entry = ReadODataEntry(model, stream);
            Console.WriteLine(entry.Properties.Single(p=>p.Name == "Name").Value);

            Console.ReadLine();
        }

        private static EdmModel BuildEdmModel()
        {
            EdmModel model = new EdmModel();

            EdmEntityContainer defaultContainer = new EdmEntityContainer(DefaultNamespace, "DefaultContainer");
            model.AddElement(defaultContainer);

            //Define entity type
            var companyType = new EdmEntityType(DefaultNamespace, "Company");
            var companyId = new EdmStructuralProperty(companyType, "CompanyID", EdmCoreModel.Instance.GetInt32(false));
            companyType.AddProperty(companyId);
            companyType.AddKeys(companyId);
            companyType.AddProperty(new EdmStructuralProperty(companyType, "Name", EdmCoreModel.Instance.GetString(true)));
            companyType.AddProperty(new EdmStructuralProperty(companyType, "Revenue",
                                                              EdmCoreModel.Instance.GetInt32(true)));
            model.AddElement(companyType);

            //Define singleton
            EdmSingleton company = new EdmSingleton(defaultContainer, "Company", companyType);
            defaultContainer.AddElement(company);

            return model;
        }

        public static ODataPath ParsePath(IEdmModel model, Uri uri)
        {
            ODataUriParser uriParser = new ODataUriParser(model, ServiceRootUri, uri);
            return uriParser.ParsePath();
        }

        private static void WriteODataEntry(IEdmModel model, Stream stream, SingletonSegment singletonSegment,
                                            ODataPath queryPath)
        {
            var entry = new ODataEntry()
                {
                    Properties = new List<ODataProperty>()
                        {
                            new ODataProperty()
                                {
                                    Name = "CompanyID",
                                    Value = 1
                                },
                            new ODataProperty()
                                {
                                    Name = "Name",
                                    Value = "Wonderland"
                                },
                            new ODataProperty()
                                {
                                    Name = "Revenue",
                                    Value = 1000
                                }
                        }
                };

            ODataMessageWriterSettings writerSettings = new ODataMessageWriterSettings();
            writerSettings.Version = ODataVersion.V4;
            writerSettings.ODataUri = new ODataUri() {ServiceRoot = ServiceRootUri, Path = queryPath};
            writerSettings.PayloadBaseUri = ServiceRootUri;
            writerSettings.SetContentType("application/json;odata.metadata=full", Encoding.UTF8.WebName);
            writerSettings.AutoComputePayloadMetadataInJson = true;

            var message = new ODataResponseMessage(stream);

            using (var messageWriter = new ODataMessageWriter(message, writerSettings, model))
            {
                var entryWriter = messageWriter.CreateODataEntryWriter(singletonSegment.Singleton,
                                                                       singletonSegment.EdmType as EdmEntityType);

                entryWriter.WriteStart(entry);
                entryWriter.WriteEnd();
                entryWriter.Flush();
            }
        }

        public static ODataEntry ReadODataEntry(EdmModel model, Stream stream)
        {
            ODataMessageReaderSettings readerSettings = new ODataMessageReaderSettings() {BaseUri = ServiceRootUri};
            var responseMessage = new ODataResponseMessage(stream);

            using (var messageReader = new ODataMessageReader(responseMessage, readerSettings, model))
            {
                var reader = messageReader.CreateODataEntryReader();

                while (reader.Read())
                {
                    switch (reader.State)
                    {
                        case ODataReaderState.EntryEnd:
                            ODataEntry entry = reader.Item as ODataEntry;
                            return entry;
                    }
                }
            }

            return null;
        }
    }
}
