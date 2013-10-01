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
    using System;

    /// <summary>
    /// Used to enable a WithFunc that does something and can revert this on disposal
    /// </summary>
    internal class WithDisposableAction : IDisposable
    {
        private Action action;

        public WithDisposableAction(Action action)
        {
            this.action = action;
        }

        /// <summary>
        /// Disposes via the action delegate
        /// </summary>
        public void Dispose()
        {
            this.action();
        }
    }
}
