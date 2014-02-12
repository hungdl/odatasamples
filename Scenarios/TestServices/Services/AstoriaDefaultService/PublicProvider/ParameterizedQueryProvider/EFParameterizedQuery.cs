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
    using System.Data.Objects;
    using System.Linq;
    using System.Collections;
    using System.Linq.Expressions;

    /// <summary>
    /// EF Parameterized Query of type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class EFParameterizedQuery<T> : IOrderedQueryable<T>, IObjectQueryWrapper
    {
        /// <summary>
        /// The original EF ObjectQuery
        /// </summary>
        readonly ObjectQuery objectQuery;

        /// <summary>
        /// The query provider
        /// </summary>
        readonly IQueryProvider queryProvider;

        /// <summary>
        /// Create an instance of type EFParameterizedQuery
        /// </summary>
        /// <param name="objectQuery">The original EF ObjectQuery</param>
        /// <param name="queryProvider">The query provider</param>
        public EFParameterizedQuery(ObjectQuery<T> objectQuery, IQueryProvider queryProvider)
        {
            this.queryProvider = queryProvider;
            this.objectQuery = objectQuery;
        }

        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns>IEnumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return queryProvider.Execute<IEnumerable<T>>(Expression).GetEnumerator();
        }

        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns>IEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Get the current expression
        /// </summary>
        public Expression Expression
        {
            get { return ((IQueryable)objectQuery).Expression; }
        }

        /// <summary>
        /// Get the element type
        /// </summary>
        public Type ElementType
        {
            get { return typeof(T); }
        }

        /// <summary>
        /// Get the query provider
        /// </summary>
        public IQueryProvider Provider
        {
            get { return queryProvider; }
        }

        /// <summary>
        /// The original EF ObjectQuery
        /// </summary>
        public ObjectQuery ObjectQuery
        {
            get { return objectQuery; }
        }
    }
}
