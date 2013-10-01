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
    
    public partial class EFMessage
    {
        public int MessageId { get; set; }
        public string FromUsername { get; set; }
        public string ToUsername { get; set; }
        public System.DateTimeOffset Sent { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsRead { get; set; }
    
        public virtual EFLogin EFLogin { get; set; }
        public virtual EFLogin EFLogin1 { get; set; }
    }
}
