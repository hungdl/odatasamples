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
    
    public partial class EFLogin
    {
        public EFLogin()
        {
            this.EFOrders = new HashSet<EFOrder>();
            this.EFRSATokens = new HashSet<EFRSAToken>();
            this.EFMessages = new HashSet<EFMessage>();
            this.EFMessages1 = new HashSet<EFMessage>();
            this.EFPageViews = new HashSet<EFPageView>();
        }
    
        public string Username { get; set; }
        public int CustomerId { get; set; }
    
        public virtual EFCustomer EFCustomer { get; set; }
        public virtual EFLastLogin EFLastLogin { get; set; }
        public virtual ICollection<EFOrder> EFOrders { get; set; }
        public virtual ICollection<EFRSAToken> EFRSATokens { get; set; }
        public virtual ICollection<EFMessage> EFMessages { get; set; }
        public virtual ICollection<EFMessage> EFMessages1 { get; set; }
        public virtual ICollection<EFPageView> EFPageViews { get; set; }
    }
}
