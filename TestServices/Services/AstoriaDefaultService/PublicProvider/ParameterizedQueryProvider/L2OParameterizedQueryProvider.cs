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
    using System.Linq;
    using System.Collections.Concurrent;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// The linq to object query provider
    /// It will visit the expression tree and replace the constant expression with parameter expression as well as extract the parameter value
    /// Then it will tried to find the delegate for the parameteried expression.
    /// If the cache is miss hit, it will create a new LambaExpression and compile to delegate.
    /// </summary>
    class L2OParameterizedQueryProvider : IQueryProvider
    {
        /// <summary>
        /// The default linq to object Expression Visit
        /// </summary>
        static readonly Func<Expression, Expression> EnumerableRewriterVisit;

        /// <summary>
        /// The cache for the delegate compiled from expression
        /// </summary>
        static readonly ConcurrentDictionary<string, Delegate> Cahce = new ConcurrentDictionary<string, Delegate>();

        /// <summary>
        /// Initialize the static readonlys
        /// </summary>
        static L2OParameterizedQueryProvider()
        {
            //Get the default l2o expression visitor, new EnumerableRewriter().Visit.
            var enumerableRewriterType = Assembly.GetAssembly(typeof(EnumerableQuery<>)).GetType("System.Linq.EnumerableRewriter");
            var visitMethod = enumerableRewriterType.GetMethod("Visit",
                BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Instance);
            var constructor = enumerableRewriterType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null,
                Type.EmptyTypes, null);
            var enumerableRewriter = constructor.Invoke(null);
            EnumerableRewriterVisit = xpr => (Expression)visitMethod.Invoke(enumerableRewriter, new object[] { xpr });
        }

        /// <summary>
        /// Create a query to wrap the default l2o IQueryable
        /// </summary>
        /// <param name="underlyingQuery">The underlying l2o queryable</param>
        /// <returns>The wrapped queryable</returns>
        public static IQueryable CreateQuery(IQueryable underlyingQuery)
        {
            var provider = new L2OParameterizedQueryProvider();
            return provider.CreateQuery(underlyingQuery.Expression);
        }

        /// <summary>
        /// Create a query from the expression
        /// </summary>
        /// <param name="expression">The expression</param>
        /// <returns>The wrapped expression</returns>
        public IQueryable CreateQuery(Expression expression)
        {
            Type elementType = expression.Type.GetQueryElementType();
            try
            {
                return (IQueryable)Activator.CreateInstance(typeof(L2OParameterizedQuery<>).MakeGenericType(elementType), new object[] { expression, this });
            }
            catch (TargetInvocationException exception)
            {
                throw exception.InnerException;
            }
        }
        /// <summary>
        /// Create a query from the expression
        /// </summary>
        /// <typeparam name="TElement">Expression element type</typeparam>
        /// <param name="expression">The expression</param>
        /// <returns>The wrapped expression</returns>
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new L2OParameterizedQuery<TElement>(expression, this);
        }

        /// <summary>
        /// Execute the expression
        /// </summary>
        /// <param name="expression">The expression</param>
        /// <returns>The result</returns>
        public object Execute(Expression expression)
        {
            object[] parameterValues;
            ParameterExpression[] parameters;
            Expression parameterizedExpression = new L2OParameterizedExpressionVisitor().Parameterize(expression,
               out parameters, out parameterValues);

            // Use the expression ToString as the cache key
            string key = parameterizedExpression.ToString();
            
            Delegate del;
            if (!Cahce.TryGetValue(key, out del))
            {
                // If cahce is miss-hit, then create a Lambda with the parameterized expression and compile it to delegate.
                // The expression has to be visited by default l2o vister EnumerableRewriter().Visit, before compile
                del = Expression.Lambda(EnumerableRewriterVisit(parameterizedExpression), parameters).Compile();
                Cahce.TryAdd(key, del);
            }
            return del.DynamicInvoke(parameterValues);
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
