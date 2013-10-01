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
    using System.Linq.Expressions;

    /// <summary>
    /// EF parameterized expression visitor
    /// </summary>
    class EFParameterizedExpressionVisitor : ExpressionVisitor
    {
        /// <summary>
        /// The parameterizable types to Tuple mapping
        /// </summary>
        readonly static Dictionary<Type, Type> ParameterizableTypes = new Dictionary<Type, Type> { 
                {typeof(bool), typeof(Tuple<bool>)},
                {typeof(byte), typeof(Tuple<byte>)},
                {typeof(DateTime), typeof(Tuple<DateTime>)},
                {typeof(DateTimeOffset), typeof(Tuple<DateTimeOffset>)},
                {typeof(decimal), typeof(Tuple<decimal>)},
                {typeof(double), typeof(Tuple<double>)},
                {typeof(float), typeof(Tuple<float>)},
                {typeof(Guid), typeof(Tuple<Guid>)},
                {typeof(short), typeof(Tuple<short>)},
                {typeof(int), typeof(Tuple<int>)},
                {typeof(long), typeof(Tuple<long>)},
                {typeof(sbyte), typeof(Tuple<sbyte>)},
                {typeof(bool?), typeof(Tuple<bool?>)},
                {typeof(byte?), typeof(Tuple<byte?>)},
                {typeof(DateTime?), typeof(Tuple<DateTime?>)},
                {typeof(DateTimeOffset?), typeof(Tuple<DateTimeOffset?>)},
                {typeof(decimal?), typeof(Tuple<decimal?>)},
                {typeof(double?), typeof(Tuple<double?>)},
                {typeof(float?), typeof(Tuple<float?>)},
                {typeof(Guid?), typeof(Tuple<Guid?>)},
                {typeof(short?), typeof(Tuple<short?>)},
                {typeof(int?), typeof(Tuple<int?>)},
                {typeof(long?), typeof(Tuple<long?>)},
                {typeof(sbyte?), typeof(Tuple<sbyte?>)},
                {typeof(string), typeof(Tuple<string>)}
            };

        /// <summary>
        /// Parameterize the expression.
        /// It will replace the ConstantExpression to PropertyExpression
        /// </summary>
        /// <param name="expression">The original expression</param>
        /// <returns>The parameterized expression</returns>
        public Expression Parameterize(Expression expression)
        {
            expression = Visit(expression);
            return expression;
        }

        /// <summary>
        /// Visit the constant expression
        /// </summary>
        /// <param name="node">The original expression node</param>
        /// <returns>The new PropertyExpression</returns>
        protected override Expression VisitConstant(ConstantExpression node)
        {
            Type tupleType;
            ParameterizableTypes.TryGetValue(node.Type, out tupleType);
            if (ParameterizableTypes.TryGetValue(node.Type, out tupleType))
            {
                //Replace the ConstantExpression to PropertyExpression of Turple<T>.Item1
                //So EF5 can parameterize it when compile the expression tree
                Object wrappedObject = Activator.CreateInstance(tupleType, new [] { node.Value });
                Expression visitedExpression = Expression.Property(Expression.Constant(wrappedObject), "Item1");
                return visitedExpression;
            }
            return base.VisitConstant(node);
        }
    }
}
