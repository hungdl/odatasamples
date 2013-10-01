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

namespace Microsoft.Test.OData.Framework.TestProviders.Reflection
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Class is used for Reflection Provider to give more information on navigation properties found on an EntityType
    /// </summary>
    internal class NavigationPropertyInfo
    {
        /// <summary>
        /// Initializes a new instance of the NavigationPropertyInfo class
        /// </summary>
        /// <param name="pi">PropertyInfo of the navigation property</param>
        /// <param name="collectionElementType">If its a collection it gives the element type, if its not generic but is a collection, object should be used</param>
        internal NavigationPropertyInfo(PropertyInfo pi, Type collectionElementType)
        {
            this.PropertyInfo = pi;
            this.CollectionElementType = collectionElementType;
        }

        /// <summary>
        /// Gets the PropertyInfo of the navigation property
        /// </summary>
        public PropertyInfo PropertyInfo { get; private set; }

        /// <summary>
        /// Gets the CollectionElementType of the navigation property
        /// </summary>
        public Type CollectionElementType { get; private set; }
    }
}
