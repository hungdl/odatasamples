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

namespace Microsoft.Test.OData.Framework.TestProviders.Contracts
{
    /// <summary>
    /// Class used to set specific actions on Data Service Providers
    /// </summary>
    public static class DataServiceOverrides
    {
        private static DataServiceActionProviderOverrides dataServiceActionProviderOverrides = new DataServiceActionProviderOverrides();
        private static DataServiceUpdatable2Overrides dataServiceUpdatable2Overrides = new DataServiceUpdatable2Overrides();

        /// <summary>
        /// Gets the Action Provider Overrides
        /// </summary>
        public static DataServiceActionProviderOverrides ActionProvider
        {
            get { return dataServiceActionProviderOverrides; }
        }

        /// <summary>
        /// Gets the UpdateProvider2 overrides
        /// </summary>
        public static DataServiceUpdatable2Overrides UpdateProvider2
        {
            get { return dataServiceUpdatable2Overrides; }
        }
    }
}
