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
    using System;
    using System.Data.Services;
    using System.Data.Services.Common;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using Microsoft.Test.OData.Services.Astoria;

    /// <summary>
    /// The EF service
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults=true, Namespace="http://microsoft.com/test/taupo/generated/")]
    public class EFService : DataService<AstoriaDefaultServiceDBEntities>, IServiceProvider
    {
        private readonly EFProvider provider;
        private readonly AstoriaDefaultServiceDBEntities dataSource;

        /// <summary>
        /// Create an instance of class EF Service
        /// </summary>
        public EFService()
        {
            dataSource = new AstoriaDefaultServiceDBEntities();
            provider = new EFProvider(this, dataSource);
        }

        /// <summary>
        /// The static constructor to ensure the database is deployed.
        /// </summary>
        static EFService()
        {
            try
            {
                DatabaseHelper.EnsureDatabaseCreated();
            }
            catch (Exception ex)
            {
                Log.Trace(ex);
                throw;
            }
        }

        /// <summary>
        /// Initialize the service
        /// </summary>
        /// <param name="config">The data service configuration</param>
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            config.SetEntitySetPageSize("*", 10);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
            config.DisableValidationOnMetadataWrite = true;
        }

        /// <summary>
        /// Create the data source
        /// </summary>
        /// <returns>The current data source</returns>
        protected override AstoriaDefaultServiceDBEntities CreateDataSource()
        {
            Log.Trace();
            return dataSource;
        }

        /// <summary>
        /// Get EFPerson count
        /// </summary>
        /// <returns>The count of EFPerson</returns>
        [WebGet]
        public int GetEFPersonCount()
        {
            return dataSource.EFPersons.Count();
        }

        /// <summary>
        /// Get EFPerson with the exact name match
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The EFPerson</returns>
        [WebGet]
        public EFPerson GetEFPersonByExactName(string name)
        {
            return dataSource.EFPersons.SingleOrDefault(p => p.Name == name);
        }

        /// <summary>
        /// Get EFPersons with the partial name match
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The EPPersons</returns>
        [WebGet]
        public IQueryable<EFPerson> GetEFPersonsByName(string name)
        {
            return dataSource.EFPersons.Where(p => p.Name.Contains(name));
        }

        /// <summary>
        /// Get service of specific type. Memeber of IServiceProvider
        /// </summary>
        /// <param name="serviceType">The service type</param>
        /// <returns>The service</returns>
        public object GetService(Type serviceType)
        {
            Log.Trace(serviceType.Name);
            if (serviceType.IsInstanceOfType(provider))
            {
                return provider;
            }
            return null;
        }

        protected override void OnStartProcessingRequest(ProcessRequestArgs args)
        {
            Log.Trace(args.RequestUri);
        }
    }
}
