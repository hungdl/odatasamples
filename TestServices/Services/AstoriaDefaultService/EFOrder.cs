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
    
    public partial class EFOrder
    {
        public EFOrder()
        {
            this.EFOrderLines = new HashSet<EFOrderLine>();
        }
    
        public int OrderId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string Concurrency_Token { get; set; }
        public Nullable<System.DateTime> Concurrency_QueriedDateTime { get; set; }
        public string Login_Orders_Username { get; set; }
    
        public virtual EFCustomer EFCustomer { get; set; }
        public virtual EFLogin EFLogin { get; set; }
        public virtual ICollection<EFOrderLine> EFOrderLines { get; set; }
    }
}
