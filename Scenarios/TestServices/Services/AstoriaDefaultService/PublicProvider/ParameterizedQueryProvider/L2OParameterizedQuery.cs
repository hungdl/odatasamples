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

namespace Microsoft.Test.OData.Services.PublicProvider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections;
    using System.Linq.Expressions;

    /// <summary>
    /// The ling to object parameterized query
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class L2OParameterizedQuery<T> : IOrderedQueryable<T>
    {
        /// <summary>
        /// The query provider
        /// </summary>
        readonly IQueryProvider queryProvider;

        /// <summary>
        /// The current expression
        /// </summary>
        readonly Expression expression;

        /// <summary>
        /// Create an instance of L2OParameterizedQuery
        /// </summary>
        /// <param name="expression">The original expression</param>
        /// <param name="queryProvider">The query builder</param>
        public L2OParameterizedQuery(Expression expression, IQueryProvider queryProvider)
        {
            this.expression = expression;
            this.queryProvider = queryProvider;
        }

        /// <summary>
        /// Get enumerator
        /// </summary>
        /// <returns>IEnumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return queryProvider.Execute<IEnumerable<T>>(expression).GetEnumerator();
        }

        /// <summary>
        /// Get enumerator
        /// </summary>
        /// <returns>IEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// The expression
        /// </summary>
        public Expression Expression
        {
            get { return expression; }
        }

        /// <summary>
        /// The expression element type
        /// </summary>
        public Type ElementType
        {
            get { return typeof(T); }
        }

        /// <summary>
        /// The query provider
        /// </summary>
        public IQueryProvider Provider
        {
            get { return queryProvider; }
        }
    }
}
