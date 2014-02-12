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
    
    public partial class EFPageView
    {
        public int PageViewId { get; set; }
        public string Username { get; set; }
        public System.DateTimeOffset Viewed { get; set; }
        public System.TimeSpan TimeSpentOnPage { get; set; }
        public string PageUrl { get; set; }
        public string C_Discriminator { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string ConcurrencyToken { get; set; }
    
        public virtual EFLogin EFLogin { get; set; }
    }
}
