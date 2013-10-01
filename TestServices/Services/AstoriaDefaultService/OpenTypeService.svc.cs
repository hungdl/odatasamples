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
    using System.Data.Services;

    [System.ServiceModel.ServiceBehaviorAttribute(IncludeExceptionDetailInFaults=true, Namespace="http://microsoft.com/test/taupo/generated/")]
    public class OpenTypeService : DataService<DefaultContainer>, Microsoft.Test.OData.Framework.TestProviders.Contracts.DataOracle.IDataServiceDataSourceCreator, System.IServiceProvider {
        
        private DefaultContainer contextInstance;
        
        public OpenTypeService() {
            this.contextInstance = new DefaultContainer(this);
        }
        
        public static void InitializeService(DataServiceConfiguration config) {
            config.UseVerboseErrors = true;
            config.DataServiceBehavior.AcceptSpatialLiteralsInQuery = false;
            config.DataServiceBehavior.MaxProtocolVersion = System.Data.Services.Common.DataServiceProtocolVersion.V3;
            config.SetEntitySetAccessRule("*", System.Data.Services.EntitySetRights.All);
            config.SetServiceActionAccessRule("*", System.Data.Services.ServiceActionRights.Invoke);
            config.SetServiceOperationAccessRule("*", System.Data.Services.ServiceOperationRights.All);
            System.Spatial.SpatialImplementation.CurrentImplementation.Operations = new Microsoft.Test.OData.Framework.TestProviders.Common.PseudoDistanceImplementation();
            config.EnableTypeAccess("*");
        }
        
        public virtual object GetService(System.Type serviceType) {
            if (((serviceType == typeof(System.Data.Services.Providers.IDataServiceUpdateProvider)) 
                        || (serviceType == typeof(System.Data.Services.IUpdatable)))) {
                return this.contextInstance;
            }
            if ((serviceType == typeof(System.Data.Services.Providers.IDataServiceQueryProvider))) {
                return this.contextInstance;
            }
            if ((serviceType == typeof(System.Data.Services.Providers.IDataServiceMetadataProvider))) {
                return this.contextInstance;
            }
            return null;
        }
        
        object Microsoft.Test.OData.Framework.TestProviders.Contracts.DataOracle.IDataServiceDataSourceCreator.CreateDataSource() {
            return this.CreateDataSource();
        }
    }
}
