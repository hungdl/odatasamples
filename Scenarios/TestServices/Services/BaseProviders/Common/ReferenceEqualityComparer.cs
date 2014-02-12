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
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Equality comparer that uses reference equality
    /// </summary>
    public class ReferenceEqualityComparer : EqualityComparer<object>
    {
        /// <summary>
        /// returns if the two objects are the same instance
        /// </summary>
        /// <param name="x">first object to compare</param>
        /// <param name="y">second object to compare</param>
        /// <returns>true if equal, false if not</returns>
        public override bool Equals(object x, object y)
        {
            return object.ReferenceEquals(x, y);
        }

        /// <summary>
        /// returns the hashcode of the object
        /// </summary>
        /// <param name="obj">object to get hashcode</param>
        /// <returns>hashcode of object</returns>
        public override int GetHashCode(object obj)
        {
            return RuntimeHelpers.GetHashCode(obj);
        }
    }
}
