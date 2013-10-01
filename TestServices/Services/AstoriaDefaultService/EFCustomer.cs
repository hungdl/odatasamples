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

namespace Microsoft.Test.OData.Services.Astoria
{
    using System;
    using System.Collections.Generic;
    
    public partial class EFCustomer
    {
        public EFCustomer()
        {
            this.EFCustomerInfoes = new HashSet<EFCustomerInfo>();
            this.EFLogins = new HashSet<EFLogin>();
            this.EFOrders = new HashSet<EFOrder>();
        }
    
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string PrimaryContactInfo_EmailBag { get; set; }
        public string PrimaryContactInfo_AlternativeNames { get; set; }
        public string PrimaryContactInfo_ContactAlias_AlternativeNames { get; set; }
        public string PrimaryContactInfo_HomePhone_PhoneNumber { get; set; }
        public string PrimaryContactInfo_HomePhone_Extension { get; set; }
        public string PrimaryContactInfo_WorkPhone_PhoneNumber { get; set; }
        public string PrimaryContactInfo_WorkPhone_Extension { get; set; }
        public string PrimaryContactInfo_MobilePhoneBag_PhoneNumber { get; set; }
        public string PrimaryContactInfo_MobilePhoneBag_Extension { get; set; }
        public string BackupContactInfo_EmailBag { get; set; }
        public string BackupContactInfo_AlternativeNames { get; set; }
        public string BackupContactInfo_ContactAlias_AlternativeNames { get; set; }
        public string BackupContactInfo_HomePhone_PhoneNumber { get; set; }
        public string BackupContactInfo_HomePhone_Extension { get; set; }
        public string BackupContactInfo_WorkPhone_PhoneNumber { get; set; }
        public string BackupContactInfo_WorkPhone_Extension { get; set; }
        public string BackupContactInfo_MobilePhoneBag_PhoneNumber { get; set; }
        public string BackupContactInfo_MobilePhoneBag_Extension { get; set; }
        public System.DateTime Auditing_ModifiedDate { get; set; }
        public string Auditing_ModifiedBy { get; set; }
        public string Auditing_Concurrency_Token { get; set; }
        public Nullable<System.DateTime> Auditing_Concurrency_QueriedDateTime { get; set; }
        public Nullable<int> Husband_Wife_CustomerId { get; set; }
    
        public virtual ICollection<EFCustomerInfo> EFCustomerInfoes { get; set; }
        public virtual ICollection<EFLogin> EFLogins { get; set; }
        public virtual ICollection<EFOrder> EFOrders { get; set; }
    }
}
