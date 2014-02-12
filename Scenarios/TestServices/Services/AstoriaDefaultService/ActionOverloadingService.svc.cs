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

namespace Microsoft.Test.OData.Services.ActionOverloadingService
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Services;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using Microsoft.Test.OData.Framework.TestProviders.Common;
    using Microsoft.Test.OData.Framework.TestProviders.Contracts.DataOracle;
    using Microsoft.Test.OData.Framework.TestProviders.OptionalProviders;
    using Microsoft.Test.OData.Framework.TestProviders.Reflection;
    using Microsoft.Test.OData.Services.AstoriaDefaultService;

    [System.ServiceModel.ServiceBehaviorAttribute(IncludeExceptionDetailInFaults = true)]
    public class ActionOverloadingService : DataService<DefaultContainer>, IDataServiceDataSourceCreator, System.IServiceProvider
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.UseVerboseErrors = true;
            config.DataServiceBehavior.AcceptSpatialLiteralsInQuery = false;
            config.DataServiceBehavior.MaxProtocolVersion = System.Data.Services.Common.DataServiceProtocolVersion.V3;
            config.SetEntitySetAccessRule("*", System.Data.Services.EntitySetRights.All);
            config.SetServiceActionAccessRule("RetrieveProduct", System.Data.Services.ServiceActionRights.Invoke);
            config.SetServiceActionAccessRule("IncreaseSalaries", System.Data.Services.ServiceActionRights.Invoke);
            config.SetServiceActionAccessRule("UpdatePersonInfo", System.Data.Services.ServiceActionRights.Invoke);
            config.SetServiceActionAccessRule("IncreaseEmployeeSalary", System.Data.Services.ServiceActionRights.Invoke);

            config.SetServiceOperationAccessRule("*", System.Data.Services.ServiceOperationRights.All);
        }

        public virtual object GetService(System.Type serviceType)
        {
            if (((serviceType == typeof(System.Data.Services.Providers.IDataServiceStreamProvider2)) || (serviceType == typeof(System.Data.Services.Providers.IDataServiceStreamProvider))))
            {
                return new InMemoryStreamProvider<ReferenceEqualityComparer>();
            }

            if (((serviceType == typeof(System.Data.Services.Providers.IDataServiceUpdateProvider)) ||
                 (serviceType == typeof(System.Data.Services.Providers.IDataServiceUpdateProvider2)) ||
                 (serviceType == typeof(System.Data.Services.IUpdatable))))
            {
                return this.CurrentDataSource;
            }

            if (serviceType == typeof(System.Data.Services.Providers.IDataServiceActionProvider))
            {
                return new ActionOverloadingTestActionProvider(this);
            }

            return null;
        }

        //
        // Service operation, actions with the same name and different binding types
        //
        [WebInvoke()]
        public int RetrieveProduct()
        {
            return this.CurrentDataSource.Product.First().ProductId;
        }

        public int RetrieveProduct(OrderLine orderLine)
        {
            return orderLine.ProductId;
        }

        public int RetrieveProduct(Product product)
        {
            return product.ProductId;
        }

        //
        // Collection bound actions with the same name
        //
        public void IncreaseSalaries(IEnumerable<Employee> employees, int n)
        {
            foreach (var employee in employees)
            {
                employee.Salary += n;
            }
        }

        public void IncreaseSalaries(IEnumerable<SpecialEmployee> specialEmployees, int n)
        {
            foreach (var specialEmployee in specialEmployees)
            {
                specialEmployee.Salary += n;
            }
        }

        //
        // Actions with the same name and base/derived type binding parameters
        //
        public void UpdatePersonInfo()
        {
            this.CurrentDataSource.Person.First().Name += "[UpdataPersonName]";
        }

        public void UpdatePersonInfo(Person person)
        {
            person.Name += "[UpdataPersonName]";
        }

        public void UpdatePersonInfo(Employee employee)
        {
            employee.Title += "[UpdateEmployeeTitle]";
        }

        public void UpdatePersonInfo(SpecialEmployee specialEmployee)
        {
            specialEmployee.Title += "[UpdateSpecialEmployeeTitle]";
        }

        public void UpdatePersonInfo(Contractor contractor)
        {
            contractor.JobDescription += "[UpdateContractorJobDescriptor]";
        }

        //
        // Actions with the same name, base/derived type binding parameters, different non-binding parameters
        //
        public bool IncreaseEmployeeSalary(Employee employee, int n)
        {
            employee.Salary += n;
            return true;
        }

        public int IncreaseEmployeeSalary(SpecialEmployee specialEmployee)
        {
            specialEmployee.Salary += 1;
            return specialEmployee.Salary;
        }

        /// <summary>
        /// Return values of request headers in response so the client tests could verify the actual requests sent
        /// </summary>
        /// <param name="args">The ProcessRequestArgs</param>
        protected override void OnStartProcessingRequest(ProcessRequestArgs args)
        {
            base.OnStartProcessingRequest(args);
            string responseHeaderValue = string.Empty;
            foreach (var header in args.OperationContext.RequestHeaders.AllKeys)
            {
                responseHeaderValue += header + "--";
                responseHeaderValue += args.OperationContext.RequestHeaders[header] + "****";
            }

            args.OperationContext.ResponseHeaders.Add("RequestHeaders", responseHeaderValue);
        }

        object IDataServiceDataSourceCreator.CreateDataSource()
        {
            return this.CreateDataSource();
        }
    }
}
