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
    using Microsoft.Test.OData.Services.AstoriaDefaultService;

    /// <summary>
    /// The reflection provider
    /// </summary>
    public class ReflectionProvider : ReflectionDataServiceProvider
    {
        /// <summary>
        /// Create an instance of class reflection provider
        /// </summary>
        /// <param name="service">The service</param>
        /// <param name="container">The reflection data source</param>
        public ReflectionProvider(ReflectionService service, DefaultContainer container)
            : base(new DataServiceProviderArgs(service, container, null, true)) {}

        /// <summary>
        /// Create an instance of class reflection provider
        /// </summary>
        /// <param name="dataServiceProviderArgs"></param>
        public ReflectionProvider(DataServiceProviderArgs dataServiceProviderArgs)
            : base(dataServiceProviderArgs) {}

        /// <summary>
        /// Override the GetQueryRootForResourceSet to fix the expression tree for Geo types and enum
        /// </summary>
        /// <param name="resourceSet"></param>
        /// <returns></returns>
        public override IQueryable GetQueryRootForResourceSet(ResourceSet resourceSet)
        {
            return L2OParameterizedQueryProvider.CreateQuery(base.GetQueryRootForResourceSet(resourceSet));
        }
    }
}
