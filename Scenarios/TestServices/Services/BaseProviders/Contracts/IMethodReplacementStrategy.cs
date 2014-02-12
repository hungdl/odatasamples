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
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// Contract for a component that helps re-write method-call expressions in expression trees
    /// </summary>
    public interface IMethodReplacementStrategy
    {
        /// <summary>
        /// Tries to get a replacement expression for the given method with the given parameters
        /// </summary>
        /// <param name="toReplace">The method to replace</param>
        /// <param name="parameters">The parameters to the method</param>
        /// <param name="replaced">The replaced expression</param>
        /// <returns>True if a replacement was made, false otherwise</returns>
        bool TryGetReplacement(MethodInfo toReplace, IEnumerable<Expression> parameters, out Expression replaced);
    }
}
