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

namespace Microsoft.Test.OData.Services.PublicProvider 
{
    using System.Data.Services.Providers;
    using System.Linq;
    using Microsoft.Test.OData.Services.Astoria;

    /// <summary>
    /// The EF Provider which inherits from EntityFrameworkDataServiceProvider
    /// </summary>
    public class EFProvider : EntityFrameworkDataServiceProvider
    {
        /// <summary>
        /// Create an instance of type EFProvider
        /// </summary>
        /// <param name="service"></param>
        /// <param name="container"></param>
        public EFProvider(EFService service, AstoriaDefaultServiceDBEntities container)
            : base(new DataServiceProviderArgs(service, container, null, false)) {}

        /// <summary>
        /// Create an instance of type EFProvider
        /// </summary>
        /// <param name="dataServiceProviderArgs"></param>
        internal EFProvider(DataServiceProviderArgs dataServiceProviderArgs)
            : base(dataServiceProviderArgs) {}

        /// <summary>
        /// Override the query root
        /// </summary>
        /// <param name="resourceSet"></param>
        /// <returns></returns>
        public override IQueryable GetQueryRootForResourceSet(ResourceSet resourceSet)
        {
            // First parameterize the expression tree, then fix the tree for Geo and Enum
            return EFParameterizedQueryProvider.CreateQuery(base.GetQueryRootForResourceSet(resourceSet));
        }

        /// <summary>
        /// Override the get resource to get underlying ObjectQuery for base.GetResource
        /// </summary>
        /// <param name="query"></param>
        /// <param name="fullTypeName"></param>
        /// <returns></returns>
        public override object GetResource(IQueryable query, string fullTypeName)
        {
            var objectQueryWrapper = query as IObjectQueryWrapper;
            var objectQuery = objectQueryWrapper == null ? query : objectQueryWrapper.ObjectQuery;
            return base.GetResource(objectQuery, fullTypeName);
        }
    }
}
