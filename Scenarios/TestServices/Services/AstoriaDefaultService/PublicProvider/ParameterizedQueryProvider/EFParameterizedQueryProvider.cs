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
    using System.Data.Objects;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// EFParameterizedQueryProvider
    /// It will visit the expression tree and replace the ConstantExpression with PropertyExpression before pass the expression to EF
    /// EF5 by default has execution plan cache enabled, and the compile plan will be parameterized.
    /// </summary>
    class EFParameterizedQueryProvider : IQueryProvider
    {
        /// <summary>
        /// Cache the CreateEFParameterizedQuery generic methodinfo
        /// </summary>
        readonly static MethodInfo CreateEFParameterizedQueryMethod =
            typeof (EFParameterizedQueryProvider).GetMethod("CreateEFParameterizedQuery",
                BindingFlags.Instance | BindingFlags.NonPublic);

        /// <summary>
        /// The underlying ef query provider
        /// </summary>
        readonly IQueryProvider underlyingQueryProvider;

        /// <summary>
        /// Create an instance of EFParameterizedQueryProvider
        /// </summary>
        /// <param name="underlyingQueryProvider">The underlying ef query providera</param>
        EFParameterizedQueryProvider(IQueryProvider underlyingQueryProvider)
        {
            this.underlyingQueryProvider = underlyingQueryProvider;
        }

        /// <summary>
        /// Craete a query from EF queryable
        /// </summary>
        /// <param name="underlyingQuery">The underlying EF query</param>
        /// <returns>The queryable EFParameterizedQuery</returns>
        public static IQueryable CreateQuery(IQueryable underlyingQuery)
        {
            var provider = new EFParameterizedQueryProvider(underlyingQuery.Provider);
            Type elementType = underlyingQuery.Expression.Type.GetQueryElementType();
            return (IQueryable)CreateEFParameterizedQueryMethod.MakeGenericMethod(elementType).Invoke(provider, new object[] { underlyingQuery.Expression, underlyingQuery });
        }

        /// <summary>
        /// Create a query from the expression
        /// </summary>
        /// <param name="expression">The expression</param>
        /// <returns>The queryable EFParameterizedQuery</returns>
        public IQueryable CreateQuery(Expression expression)
        {
            Type elementType = expression.Type.GetQueryElementType();
            return (IQueryable)CreateEFParameterizedQueryMethod.MakeGenericMethod(elementType).Invoke(this, new object[] { expression, null });
        }

        /// <summary>
        /// Create a query from the expression
        /// </summary>
        /// <typeparam name="TElement">The element type</typeparam>
        /// <param name="expression">The expression</param>
        /// <returns>The queryable EFParameterizedQuery</returns>
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return CreateEFParameterizedQuery<TElement>(expression, null);
        }

        /// <summary>
        /// Create a EFParameterizedQuery from the expression and original IQueryable if we have
        /// </summary>
        /// <typeparam name="TElement">The element type</typeparam>
        /// <param name="expression">The expression</param>
        /// <param name="queryable">The original IQueryable</param>
        /// <returns></returns>
        private EFParameterizedQuery<TElement> CreateEFParameterizedQuery<TElement>(Expression expression, IQueryable queryable)
        {
            var objectQuery = queryable as ObjectQuery<TElement> ??
                              (ObjectQuery<TElement>)this.underlyingQueryProvider.CreateQuery<TElement>(expression);
            return new EFParameterizedQuery<TElement>(objectQuery, this);
        }

        /// <summary>
        /// Execute the expression
        /// </summary>
        /// <param name="expression">The expression</param>
        /// <returns>The result</returns>
        public object Execute(Expression expression)
        {
            Expression parameterizedExpression = new EFParameterizedExpressionVisitor().Parameterize(expression);
            if (typeof(IQueryable).IsAssignableFrom(expression.Type))
            {
                return underlyingQueryProvider.CreateQuery(parameterizedExpression);
            }
            return underlyingQueryProvider.Execute(parameterizedExpression);
        }

        /// <summary>
        /// Execute the expression
        /// </summary>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <param name="expression">The expression</param>
        /// <returns>The result</returns>
        public TResult Execute<TResult>(Expression expression)
        {
            return (TResult)Execute(expression);
        }
    }
}
