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

namespace Microsoft.Test.OData.Services.OpenTypesService {
    using System;
    using System.Collections.Generic;
    using System.Data.Services;
    using System.Data.Services.Common;
    using System.Data.Services.Providers;
    using System.Linq;


    public class DefaultContainer_Metadata : Microsoft.Test.OData.Framework.TestProviders.Dictionary.DictionaryMetadataHelper
    {
        
        public DefaultContainer_Metadata() {
            // ComplexTypes declared here

            Microsoft.Test.OData.Framework.TestProviders.Common.LazyResourceType contactdetails_ComplexType = new Microsoft.Test.OData.Framework.TestProviders.Common.LazyResourceType(typeof(Microsoft.Test.OData.Framework.TestProviders.Dictionary.ResourceInstance), ResourceTypeKind.ComplexType, null, "Microsoft.Test.OData.Services.OpenTypesService", "ContactDetails", false);
            contactdetails_ComplexType.IsOpenType = false;
            contactdetails_ComplexType.CanReflectOnInstanceType = false;
            this.ResourceTypes.Add(contactdetails_ComplexType);

            // ComplexTypes properties declared

            ResourceProperty contactdetails_FirstContacted = new ResourceProperty("FirstContacted", ResourcePropertyKind.Primitive, ResourceType.GetPrimitiveResourceType(typeof(byte[])));
            contactdetails_FirstContacted.CanReflectOnInstanceTypeProperty = false;
            contactdetails_ComplexType.AddLazyProperty(contactdetails_FirstContacted);
            ResourceProperty contactdetails_LastContacted = new ResourceProperty("LastContacted", ResourcePropertyKind.Primitive, ResourceType.GetPrimitiveResourceType(typeof(System.DateTimeOffset)));
            contactdetails_LastContacted.CanReflectOnInstanceTypeProperty = false;
            contactdetails_ComplexType.AddLazyProperty(contactdetails_LastContacted);
            ResourceProperty contactdetails_Contacted = new ResourceProperty("Contacted", ResourcePropertyKind.Primitive, ResourceType.GetPrimitiveResourceType(typeof(System.DateTime)));
            contactdetails_Contacted.CanReflectOnInstanceTypeProperty = false;
            contactdetails_ComplexType.AddLazyProperty(contactdetails_Contacted);
            ResourceProperty contactdetails_GUID = new ResourceProperty("GUID", ResourcePropertyKind.Primitive, ResourceType.GetPrimitiveResourceType(typeof(System.Guid)));
            contactdetails_GUID.CanReflectOnInstanceTypeProperty = false;
            contactdetails_ComplexType.AddLazyProperty(contactdetails_GUID);
            ResourceProperty contactdetails_PreferedContactTime = new ResourceProperty("PreferedContactTime", ResourcePropertyKind.Primitive, ResourceType.GetPrimitiveResourceType(typeof(System.TimeSpan)));
            contactdetails_PreferedContactTime.CanReflectOnInstanceTypeProperty = false;
            contactdetails_ComplexType.AddLazyProperty(contactdetails_PreferedContactTime);
            ResourceProperty contactdetails_Byte = new ResourceProperty("Byte", ResourcePropertyKind.Primitive, ResourceType.GetPrimitiveResourceType(typeof(byte)));
            contactdetails_Byte.CanReflectOnInstanceTypeProperty = false;
            contactdetails_ComplexType.AddLazyProperty(contactdetails_Byte);
            ResourceProperty contactdetails_SignedByte = new ResourceProperty("SignedByte", ResourcePropertyKind.Primitive, ResourceType.GetPrimitiveResourceType(typeof(sbyte)));
            contactdetails_SignedByte.CanReflectOnInstanceTypeProperty = false;
            contactdetails_ComplexType.AddLazyProperty(contactdetails_SignedByte);
            ResourceProperty contactdetails_Double = new ResourceProperty("Double", ResourcePropertyKind.Primitive, ResourceType.GetPrimitiveResourceType(typeof(double)));
            contactdetails_Double.CanReflectOnInstanceTypeProperty = false;
            contactdetails_ComplexType.AddLazyProperty(contactdetails_Double);
            ResourceProperty contactdetails_Single = new ResourceProperty("Single", ResourcePropertyKind.Primitive, ResourceType.GetPrimitiveResourceType(typeof(float)));
            contactdetails_Single.CanReflectOnInstanceTypeProperty = false;
            contactdetails_ComplexType.AddLazyProperty(contactdetails_Single);
            ResourceProperty contactdetails_Short = new ResourceProperty("Short", ResourcePropertyKind.Primitive, ResourceType.GetPrimitiveResourceType(typeof(short)));
            contactdetails_Short.CanReflectOnInstanceTypeProperty = false;
            contactdetails_ComplexType.AddLazyProperty(contactdetails_Short);
            ResourceProperty contactdetails_Int = new ResourceProperty("Int", ResourcePropertyKind.Primitive, ResourceType.GetPrimitiveResourceType(typeof(int)));
            contactdetails_Int.CanReflectOnInstanceTypeProperty = false;
            contactdetails_ComplexType.AddLazyProperty(contactdetails_Int);
            ResourceProperty contactdetails_Long = new ResourceProperty("Long", ResourcePropertyKind.Primitive, ResourceType.GetPrimitiveResourceType(typeof(long)));
            contactdetails_Long.CanReflectOnInstanceTypeProperty = false;
            contactdetails_ComplexType.AddLazyProperty(contactdetails_Long);

            // EntityTypes declared here

            Microsoft.Test.OData.Framework.TestProviders.Common.LazyResourceType row_EntityType = new Microsoft.Test.OData.Framework.TestProviders.Common.LazyResourceType(typeof(Microsoft.Test.OData.Framework.TestProviders.Dictionary.ResourceInstance), ResourceTypeKind.EntityType, null, "Microsoft.Test.OData.Services.OpenTypesService", "Row", false);
            row_EntityType.IsOpenType = true;
            row_EntityType.CanReflectOnInstanceType = false;
            this.ResourceTypes.Add(row_EntityType);

            Microsoft.Test.OData.Framework.TestProviders.Common.LazyResourceType indexedrow_EntityType = new Microsoft.Test.OData.Framework.TestProviders.Common.LazyResourceType(typeof(Microsoft.Test.OData.Framework.TestProviders.Dictionary.ResourceInstance), ResourceTypeKind.EntityType, row_EntityType, "Microsoft.Test.OData.Services.OpenTypesService", "IndexedRow", false);
            indexedrow_EntityType.IsOpenType = true;
            indexedrow_EntityType.CanReflectOnInstanceType = false;
            this.ResourceTypes.Add(indexedrow_EntityType);

            Microsoft.Test.OData.Framework.TestProviders.Common.LazyResourceType rowindex_EntityType = new Microsoft.Test.OData.Framework.TestProviders.Common.LazyResourceType(typeof(Microsoft.Test.OData.Framework.TestProviders.Dictionary.ResourceInstance), ResourceTypeKind.EntityType, null, "Microsoft.Test.OData.Services.OpenTypesService", "RowIndex", false);
            rowindex_EntityType.IsOpenType = true;
            rowindex_EntityType.CanReflectOnInstanceType = false;
            this.ResourceTypes.Add(rowindex_EntityType);

            // EntityType primitive and complexType properties declared here

            ResourceProperty row_Id = new ResourceProperty("Id", (ResourcePropertyKind.Primitive | ResourcePropertyKind.Key), ResourceType.GetPrimitiveResourceType(typeof(System.Guid)));
            row_Id.CanReflectOnInstanceTypeProperty = false;
            row_EntityType.AddLazyProperty(row_Id);


            ResourceProperty rowindex_Id = new ResourceProperty("Id", (ResourcePropertyKind.Primitive | ResourcePropertyKind.Key), ResourceType.GetPrimitiveResourceType(typeof(int)));
            rowindex_Id.CanReflectOnInstanceTypeProperty = false;
            rowindex_EntityType.AddLazyProperty(rowindex_Id);

            // EntityTypes navigation properties declared here



            ResourceProperty rowindex_Rows = new ResourceProperty("Rows", ResourcePropertyKind.ResourceSetReference, indexedrow_EntityType);
            rowindex_Rows.CanReflectOnInstanceTypeProperty = false;
            rowindex_EntityType.AddLazyProperty(rowindex_Rows);
            // Add EntitySet Declarations

            var row_EntitySet = new ResourceSet("Row", row_EntityType);
            this.ResourceSets.Add(row_EntitySet);

            var rowindex_EntitySet = new ResourceSet("RowIndex", rowindex_EntityType);
            this.ResourceSets.Add(rowindex_EntitySet);

            // Add AssociationSet Declarations

            System.Data.Services.Providers.ResourceAssociationSet index_rows_AssociationSet = new ResourceAssociationSet("Index_Rows", new ResourceAssociationSetEnd(rowindex_EntitySet, rowindex_EntityType, rowindex_Rows), new ResourceAssociationSetEnd(row_EntitySet, indexedrow_EntityType, null));
            this.ResourceAssociationSets.Add(index_rows_AssociationSet);
            // ServiceOperations declared here

            row_EntitySet.SetReadOnly();
            rowindex_EntitySet.SetReadOnly();

            row_EntityType.SetReadOnly();
            indexedrow_EntityType.SetReadOnly();
            rowindex_EntityType.SetReadOnly();

            contactdetails_ComplexType.SetReadOnly();

        }
    }
}
