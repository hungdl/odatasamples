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

namespace Microsoft.Test.OData.Services.UrlModifyingService
{
    using System;
    using System.Data.Services;
    using Microsoft.Test.OData.Services.AstoriaDefaultService;

    [System.ServiceModel.ServiceBehaviorAttribute(IncludeExceptionDetailInFaults = true)]
    public class UrlModifyingService : Service
    {
        public ProcessRequestArgs StoredArgs { get; private set; }
                
        protected override void OnStartProcessingRequest(ProcessRequestArgs args)
        {
            if (args.RequestUri.AbsoluteUri.Contains("RemapPath"))
            {
                args.RequestUri = new Uri(args.ServiceUri.AbsoluteUri + "Customer");
            }
            else if (args.RequestUri.AbsoluteUri.Contains("RemapBase"))
            {
                args.ServiceUri = new Uri("http://potato" + args.ServiceUri.AbsoluteUri.Substring(args.ServiceUri.AbsoluteUri.IndexOf(':', 5)));
                args.RequestUri = new Uri(args.ServiceUri.AbsoluteUri + "Customer");
            }
            else if (args.RequestUri.AbsoluteUri.Contains("RemapBaseAndPathSeparately"))
            {
                // Service Uri and Request Uri have different bases
                args.RequestUri = new Uri(args.ServiceUri.AbsoluteUri + "Customer");
                args.ServiceUri = new Uri("http://potato" + args.ServiceUri.AbsoluteUri.Substring(args.ServiceUri.AbsoluteUri.IndexOf(':', 5)));   
            }
            else if (args.RequestUri.AbsoluteUri.Contains("BasesDontMatchFail"))
            {
                // Service Uri and Request Uri have different bases
                args.RequestUri = new Uri("http://potato:9090/DontFailMeService/Customer");
                args.ServiceUri = new Uri("http://potato:9090/FailMeService");
            }
            else if (args.RequestUri.AbsoluteUri.Contains("$batch"))
            {
                args.ServiceUri = new Uri("http://potato" + args.ServiceUri.AbsoluteUri.Substring(args.ServiceUri.AbsoluteUri.IndexOf(':', 5)));
            }
            else if (args.RequestUri.AbsoluteUri.Contains("BatchRequest1"))
            {
                args.RequestUri = new Uri(args.ServiceUri.AbsoluteUri + "Customer");
            }
            else if (args.RequestUri.AbsoluteUri.Contains("BatchRequest2"))
            {
                args.RequestUri = new Uri(args.ServiceUri.AbsoluteUri + "Person");
            }
            else if (args.RequestUri.AbsoluteUri.Contains("BatchRequest3"))
            {
                args.ServiceUri = new Uri("http://notpotato:9090/yummy");
                args.RequestUri = new Uri("http://notpotato:9090/yummy/Customer");
            }
            else if (args.RequestUri.AbsoluteUri.Contains("Person"))
            {
                args.RequestUri = new Uri(args.RequestUri.AbsoluteUri + "?$top=5");
            }
            
            base.OnStartProcessingRequest(args);            
        }
    }
}
