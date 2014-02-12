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

namespace Microsoft.Test.OData.Services.AstoriaDefaultService
{
    using System;
    using System.Collections.Generic;
    using System.Data.Services.Providers;
    using Microsoft.Test.OData.Framework.TestProviders.OptionalProviders;

    public class AstoriaDefaultActionProvider : TestDataServiceActionProvider
    {
        public AstoriaDefaultActionProvider(object dataServiceInstance) : base(dataServiceInstance)
        {
        }

        protected override IEnumerable<ServiceAction> LoadServiceActions(IDataServiceMetadataProvider dataServiceMetadataProvider)
        {
            ResourceType employeeType;
            dataServiceMetadataProvider.TryResolveResourceType("Microsoft.Test.OData.Services.AstoriaDefaultService.Employee", out employeeType);
            ResourceType computerDetailType;
            dataServiceMetadataProvider.TryResolveResourceType("Microsoft.Test.OData.Services.AstoriaDefaultService.ComputerDetail", out computerDetailType);
            ResourceType computerType;          
            dataServiceMetadataProvider.TryResolveResourceType("Microsoft.Test.OData.Services.AstoriaDefaultService.Computer", out computerType);
            ResourceType customerType;
            dataServiceMetadataProvider.TryResolveResourceType("Microsoft.Test.OData.Services.AstoriaDefaultService.Customer", out customerType);
            ResourceType auditInfoType;
            dataServiceMetadataProvider.TryResolveResourceType("Microsoft.Test.OData.Services.AstoriaDefaultService.AuditInfo", out auditInfoType);            
            ResourceSet computerSet;
            dataServiceMetadataProvider.TryResolveResourceSet("Computer", out computerSet);
            var increaseSalaryAction = new ServiceAction(
                 "IncreaseSalaries",
                 null,
                 null,
                 OperationParameterBindingKind.Always,
                 new[]
                {
                    new ServiceActionParameter("employees", ResourceType.GetEntityCollectionResourceType(employeeType)),
                    new ServiceActionParameter("n", ResourceType.GetPrimitiveResourceType(typeof(int))),
                });

            increaseSalaryAction.SetReadOnly();

            yield return increaseSalaryAction;

            var sackEmployeeAction = new ServiceAction(
                "Sack",
                null,
                null,
                OperationParameterBindingKind.Always,
                new[]
                {
                    new ServiceActionParameter("employee", employeeType), 
                });

            sackEmployeeAction.SetReadOnly();

            yield return sackEmployeeAction;

            var getComputerAction = new ServiceAction(
                "GetComputer",
                computerType,
                computerSet,
                OperationParameterBindingKind.Always,
                new[]
                {
                    new ServiceActionParameter("computer", computerType)
                });

            getComputerAction.SetReadOnly();

            yield return getComputerAction;
             
            var changeCustomerAuditInfoAction = new ServiceAction(
               "ChangeCustomerAuditInfo",
               null,
               null,
               OperationParameterBindingKind.Always,
               new[]
                {
                
                    new ServiceActionParameter("customer", customerType), 
                    new ServiceActionParameter("auditInfo", auditInfoType),
                });

            changeCustomerAuditInfoAction.SetReadOnly();

            yield return changeCustomerAuditInfoAction;

             var resetComputerDetailsSpecificationsAction = new ServiceAction(
                "ResetComputerDetailsSpecifications",
                null,
                null,
                OperationParameterBindingKind.Always,
                new[]
                {
                    new ServiceActionParameter("computerDetail", computerDetailType), 
                    new ServiceActionParameter("specifications", ResourceType.GetCollectionResourceType(ResourceType.GetPrimitiveResourceType(typeof(string)))),
                    new ServiceActionParameter("purchaseTime", ResourceType.GetPrimitiveResourceType(typeof(DateTime)))
                });

            resetComputerDetailsSpecificationsAction.SetReadOnly();

            yield return resetComputerDetailsSpecificationsAction;
        }
    }
}
