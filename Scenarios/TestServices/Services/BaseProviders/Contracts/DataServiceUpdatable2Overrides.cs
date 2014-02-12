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
    using System.Data.Services.Providers;
    using System.Linq;

    /// <summary>
    /// Class used to set specific actions on Data Service Providers
    /// </summary>
    public class DataServiceUpdatable2Overrides
    {
        internal Action<IDataServiceInvokable> AddPendingActionsCreateInvokableFunc { get; private set; }

        internal Action<IDataServiceInvokable> ImmediateCreateInvokableFunc { get; private set; }

        internal Func<IQueryable, object> GetResourcesFunc { get; private set; }

        /// <summary>
        /// Sets the WithCreateInvokable and disposes of it when dispose is called
        /// </summary>
        /// <param name="addInvokableFunc">Add Invokable Func</param>
        /// <returns>Disposable of WithGetServiceActionsByBindingParameterTypeFunc</returns>
        public IDisposable WithImmediateCreateInvokable(Action<IDataServiceInvokable> addInvokableFunc)
        {
            this.ImmediateCreateInvokableFunc = addInvokableFunc;
            return new WithDisposableAction(() => this.ImmediateCreateInvokableFunc = null);
        }

        /// <summary>
        /// Sets the WithCreateInvokable and disposes of it when dispose is called
        /// </summary>
        /// <param name="addInvokableFunc">Add Invokable Func</param>
        /// <returns>Disposable of WithGetServiceActionsByBindingParameterTypeFunc</returns>
        public IDisposable WithPendingActionsCreateInvokable(Action<IDataServiceInvokable> addInvokableFunc)
        {
            this.AddPendingActionsCreateInvokableFunc = addInvokableFunc;
            return new WithDisposableAction(() => this.AddPendingActionsCreateInvokableFunc = null);
        }

        /// <summary>
        /// Sets the GetResources Func and disposes of it when dispose is called
        /// </summary>
        /// <param name="getResourcesFunc">Get Resources Func</param>
        /// <returns>Disposable of WithGetServiceActionsByBindingParameterTypeFunc</returns>
        public IDisposable WithGetResources(Func<IQueryable, object> getResourcesFunc)
        {
            this.GetResourcesFunc = getResourcesFunc;
            return new WithDisposableAction(() => this.GetResourcesFunc = null);
        }
    }
}
