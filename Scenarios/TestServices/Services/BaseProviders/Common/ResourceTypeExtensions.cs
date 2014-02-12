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

namespace Microsoft.Test.OData.Framework.TestProviders.Common
{
    using System;
    using System.Collections.Generic;
    using System.Data.Services.Providers;
    using System.Linq;

    /// <summary>
    /// Extension methods for the products metadata APIs
    /// </summary>
    public static class ResourceTypeExtensions
    {
        /// <summary>
        /// Returns all properties on the type without explicitly loading them if the type is lazy
        /// </summary>
        /// <param name="resourceType">The resource type to get all the properties for</param>
        /// <returns>All the properties for the type, including those on any base type(s)</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Taupo.DataServices", "TDS0001:ResourceTypePropertiesAccessRule", 
            Justification = "This is the helper method to access the properties safely")]
        public static IEnumerable<ResourceProperty> GetAllPropertiesLazily(this ResourceType resourceType)
        {
            ExceptionUtilities.CheckArgumentNotNull(resourceType, "resourceType");

            var lazyType = resourceType as LazyResourceType;
            if (lazyType != null)
            {
                IEnumerable<ResourceProperty> properties = lazyType.LazyProperties;
                if (lazyType.BaseType != null)
                {
                    properties = lazyType.BaseType.GetAllPropertiesLazily().Concat(properties);
                }

                return properties;
            }

            return resourceType.Properties;
        }

        /// <summary>
        /// Returns only the properties locally defined on the given type without explicitly loading them if the type is lazy
        /// </summary>
        /// <param name="resourceType">The resource type to get properties for</param>
        /// <returns>Only the locally defined properties for the type</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Taupo.DataServices", "TDS0001:ResourceTypePropertiesAccessRule",
            Justification = "This is the helper method to access the properties safely")]
        public static IEnumerable<ResourceProperty> GetLocalPropertiesLazily(this ResourceType resourceType)
        {
            ExceptionUtilities.CheckArgumentNotNull(resourceType, "resourceType");

            var lazyType = resourceType as LazyResourceType;
            if (lazyType != null)
            {
                return lazyType.LazyProperties;
            }

            return resourceType.PropertiesDeclaredOnThisType;
        }
    }
}
