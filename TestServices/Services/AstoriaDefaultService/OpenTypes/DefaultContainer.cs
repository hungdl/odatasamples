//   Copyright 2011 Microsoft Corporation
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

namespace Microsoft.Test.OData.Services.OpenTypesService 
{
    using System;
    using System.Collections.Generic;
    using System.Data.Services;
    using System.Data.Services.Providers;
    using Microsoft.Test.OData.Framework.TestProviders.Dictionary;

    public class DefaultContainer : Microsoft.Test.OData.Framework.TestProviders.Dictionary.DictionaryDataContext, System.Data.Services.Providers.IDataServiceMetadataProvider, System.Data.Services.Providers.IDataServiceQueryProvider, System.Data.Services.Providers.IDataServiceUpdateProvider
    {
        private static bool dataInitialized = false;
        
        private static object lockObject = new object();

        private static Dictionary<string, System.Type> collectionInstanceTypeMap = new Dictionary<string, System.Type>();

        private static Dictionary<string, int> autoIncrementingProperties = new Dictionary<string, int>();

        static DefaultContainer()
        {
            collectionInstanceTypeMap.Add("Microsoft.Test.OData.Services.OpenTypesService.RowIndex.Rows", typeof(System.Collections.Generic.List<Microsoft.Test.OData.Framework.TestProviders.Dictionary.ResourceInstance>));
        }

        public DefaultContainer() :
            this(null)
        {
        }

        public DefaultContainer(object dataServiceInstance) :
            base(dataServiceInstance)
        {
        }

        protected override void EnsureDataIsInitialized() 
        {
            System.Threading.Monitor.Enter(DefaultContainer.lockObject);
            try 
            {
                if ((DefaultContainer.dataInitialized == false)) 
                {
                    DefaultContainer.InitializeData(this);
                    DefaultContainer.dataInitialized = true;
                }
            }
            finally 
            {
                System.Threading.Monitor.Exit(DefaultContainer.lockObject);
            }
        }
        
        private static void InitializeData(System.Data.Services.IUpdatable updatable) 
        {
            System.Collections.Generic.Dictionary<string, object> resourceLookup = new System.Collections.Generic.Dictionary<string, object>();
            PopulateRow(updatable, resourceLookup);
            PopulateRowIndex(updatable, resourceLookup);
            PopulateIndex_Rows(updatable, resourceLookup);
            updatable.SaveChanges();
        }
        
        private static void PopulateRow(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup) 
        {

            resourceLookup.Add("Row0", updatable.CreateResource("Row", "Microsoft.Test.OData.Services.OpenTypesService.IndexedRow"));
            updatable.SetValue(resourceLookup["Row0"], "Id", new System.Guid("432f0da9-806e-4a2f-b708-dbd1c57a1c21"));
            updatable.SetValue(resourceLookup["Row0"], "Name", "Chris");


            resourceLookup.Add("Row1", updatable.CreateResource("Row", "Microsoft.Test.OData.Services.OpenTypesService.IndexedRow"));
            updatable.SetValue(resourceLookup["Row1"], "Id", new System.Guid("02d5d465-edb3-4169-9176-89dd7c86535e"));
            updatable.SetValue(resourceLookup["Row1"], "Description", "Excellent");

            resourceLookup.Add("Row2", updatable.CreateResource("Row", "Microsoft.Test.OData.Services.OpenTypesService.IndexedRow"));
            updatable.SetValue(resourceLookup["Row2"], "Id", new System.Guid("8f59bcb4-1bed-4b91-ab74-44628f57f160"));
            updatable.SetValue(resourceLookup["Row2"], "Count", 1);

            resourceLookup.Add("Row3", updatable.CreateResource("Row", "Microsoft.Test.OData.Services.OpenTypesService.IndexedRow"));
            updatable.SetValue(resourceLookup["Row3"], "Id", new System.Guid("5dcbef86-a002-4121-8087-f6160fe9a1ed"));
            updatable.SetValue(resourceLookup["Row3"], "Occurred", new DateTimeOffset(2001, 4, 5, 5, 5, 5, 1, new TimeSpan(0, 1, 0)));

            resourceLookup.Add("Row4", updatable.CreateResource("Row", "Microsoft.Test.OData.Services.OpenTypesService.Row"));
            updatable.SetValue(resourceLookup["Row4"], "Id", new System.Guid("71f7d0dc-ede4-45eb-b421-555a2aa1e58f"));
            updatable.SetValue(resourceLookup["Row4"], "Double", 1.2626d);

            resourceLookup.Add("Row5", updatable.CreateResource("Row", "Microsoft.Test.OData.Services.OpenTypesService.Row"));
            updatable.SetValue(resourceLookup["Row5"], "Id", new System.Guid("672b8250-1e6e-4785-80cf-b94b572e42b3"));
            updatable.SetValue(resourceLookup["Row5"], "Decimal", new Decimal(1.26d));

            resourceLookup.Add("Row6", updatable.CreateResource("Row", "Microsoft.Test.OData.Services.OpenTypesService.Row"));
            updatable.SetValue(resourceLookup["Row6"], "Id", new System.Guid("814d505b-6b6a-45a0-9de0-153b16149d56"));
            updatable.SetValue(resourceLookup["Row6"], "Date", new DateTime(1999, 2, 4));

            resourceLookup.Add("Row7", updatable.CreateResource("Row", "Microsoft.Test.OData.Services.OpenTypesService.Row"));
            updatable.SetValue(resourceLookup["Row7"], "Id", new System.Guid("2e4904b4-00b0-4e37-9f44-b99a6b208dba"));
            updatable.SetValue(resourceLookup["Row7"], "GeomPolygon", System.Spatial.WellKnownTextSqlFormatter.Create().Read<System.Spatial.GeometryPolygon>(new System.IO.StringReader("SRID=0;POLYGON EMPTY")));

            resourceLookup.Add("Row8", updatable.CreateResource("Row", "Microsoft.Test.OData.Services.OpenTypesService.Row"));
            updatable.SetValue(resourceLookup["Row8"], "Id", new System.Guid("5a76c54e-4553-4bf6-8592-04cbcbfb1e65"));

            resourceLookup.Add("Row9", updatable.CreateResource("Row", "Microsoft.Test.OData.Services.OpenTypesService.IndexedRow"));
            updatable.SetValue(resourceLookup["Row9"], "Id", new System.Guid("9f9c963b-5c2f-4e39-8bec-b45d19c5dc85"));
        }
        
        private static void PopulateRowIndex(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup) 
        {

            resourceLookup.Add("RowIndex0", updatable.CreateResource("RowIndex", "Microsoft.Test.OData.Services.OpenTypesService.RowIndex"));
            updatable.SetValue(resourceLookup["RowIndex0"], "Id", -10);


            resourceLookup.Add("RowIndex1", updatable.CreateResource("RowIndex", "Microsoft.Test.OData.Services.OpenTypesService.RowIndex"));
            updatable.SetValue(resourceLookup["RowIndex1"], "Id", -9);


            resourceLookup.Add("RowIndex2", updatable.CreateResource("RowIndex", "Microsoft.Test.OData.Services.OpenTypesService.RowIndex"));
            updatable.SetValue(resourceLookup["RowIndex2"], "Id", -8);


            resourceLookup.Add("RowIndex3", updatable.CreateResource("RowIndex", "Microsoft.Test.OData.Services.OpenTypesService.RowIndex"));
            updatable.SetValue(resourceLookup["RowIndex3"], "Id", -7);


            resourceLookup.Add("RowIndex4", updatable.CreateResource("RowIndex", "Microsoft.Test.OData.Services.OpenTypesService.RowIndex"));
            updatable.SetValue(resourceLookup["RowIndex4"], "Id", -6);


            resourceLookup.Add("RowIndex5", updatable.CreateResource("RowIndex", "Microsoft.Test.OData.Services.OpenTypesService.RowIndex"));
            updatable.SetValue(resourceLookup["RowIndex5"], "Id", -5);


            resourceLookup.Add("RowIndex6", updatable.CreateResource("RowIndex", "Microsoft.Test.OData.Services.OpenTypesService.RowIndex"));
            updatable.SetValue(resourceLookup["RowIndex6"], "Id", -4);


            resourceLookup.Add("RowIndex7", updatable.CreateResource("RowIndex", "Microsoft.Test.OData.Services.OpenTypesService.RowIndex"));
            updatable.SetValue(resourceLookup["RowIndex7"], "Id", -3);


            resourceLookup.Add("RowIndex8", updatable.CreateResource("RowIndex", "Microsoft.Test.OData.Services.OpenTypesService.RowIndex"));
            updatable.SetValue(resourceLookup["RowIndex8"], "Id", -2);


            resourceLookup.Add("RowIndex9", updatable.CreateResource("RowIndex", "Microsoft.Test.OData.Services.OpenTypesService.RowIndex"));
            updatable.SetValue(resourceLookup["RowIndex9"], "Id", -1);

        }

        protected override Microsoft.Test.OData.Framework.TestProviders.Dictionary.DictionaryMetadataHelper CreateMetadataHelper()
        {
            return new DefaultContainer_Metadata();
        }

        protected override System.Collections.Generic.IEnumerable<Microsoft.Test.OData.Framework.TestProviders.Contracts.IMethodReplacementStrategy> MethodReplacementStrategies
        {
            get
            {
                return new Microsoft.Test.OData.Framework.TestProviders.Contracts.IMethodReplacementStrategy[] {
                        new Microsoft.Test.OData.Framework.TestProviders.Dictionary.DefaultDataServiceProviderMethodsReplacementStrategy(((System.Data.Services.Providers.IDataServiceQueryProvider)(this))),
                        new Microsoft.Test.OData.Framework.TestProviders.Dictionary.RealisticOpenTypeMethodsReplacementStrategy(((System.Data.Services.Providers.IDataServiceQueryProvider)(this)))};
            }
        }

        protected override System.Type GetCollectionPropertyType(string fullTypeName, string propertyName)
        {
            var key = string.Concat(fullTypeName, ".", propertyName);
            if (collectionInstanceTypeMap.ContainsKey(key))
            {
                return collectionInstanceTypeMap[key];
            }
            return base.GetCollectionPropertyType(fullTypeName, propertyName);
        }

        protected override bool TryGetStoreGeneratedValue(string entitySetName, string fullTypeName, string propertyName, out object propertyValue)
        {
            var key = string.Concat(entitySetName, ".", propertyName);
            if (autoIncrementingProperties.ContainsKey(key))
            {
                autoIncrementingProperties[key] = (autoIncrementingProperties[key] + 1);
                propertyValue = autoIncrementingProperties[key];
                return true;
            }
            return base.TryGetStoreGeneratedValue(entitySetName, fullTypeName, propertyName, out propertyValue);
        }
        
        private static void PopulateIndex_Rows(System.Data.Services.IUpdatable updatable, System.Collections.Generic.Dictionary<string, object> resourceLookup) {
            updatable.AddReferenceToCollection(resourceLookup["RowIndex1"], "Rows", resourceLookup["Row0"]);
            updatable.AddReferenceToCollection(resourceLookup["RowIndex3"], "Rows", resourceLookup["Row1"]);
            updatable.AddReferenceToCollection(resourceLookup["RowIndex3"], "Rows", resourceLookup["Row3"]);
            updatable.AddReferenceToCollection(resourceLookup["RowIndex4"], "Rows", resourceLookup["Row9"]);
        }
    }
}
