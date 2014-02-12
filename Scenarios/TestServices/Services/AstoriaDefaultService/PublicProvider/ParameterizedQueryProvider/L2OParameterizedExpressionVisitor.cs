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
    /// Linq to object parameterized expression visitor
    /// </summary>
    class L2OParameterizedExpressionVisitor : ExpressionVisitor
    {
        public readonly static Dictionary<Type, bool> ParameterizableTypes = new Dictionary<Type, bool> { 
                {typeof(bool), true},
                {typeof(byte),  true},
                {typeof(DateTime),  true},
                {typeof(DateTimeOffset),  true},
                {typeof(decimal),  true},
                {typeof(double),  true},
                {typeof(float),  true},
                {typeof(Guid),  true},
                {typeof(short),  true},
                {typeof(int),  true},
                {typeof(long),  true},
                {typeof(sbyte),  true},
                {typeof(bool?),  true},
                {typeof(byte?),  true},
                {typeof(DateTime?),  true},
                {typeof(DateTimeOffset?),  true},
                {typeof(decimal?),  true},
                {typeof(double?),  true},
                {typeof(float?),  true},
                {typeof(Guid?),  true},
                {typeof(short?),  true},
                {typeof(int?),  true},
                {typeof(long?),  true},
                {typeof(sbyte?),  true},
                {typeof(string),  true}
            };

        /// <summary>
        /// The parameter expression list
        /// </summary>
        readonly List<ParameterExpression> parameters = new List<ParameterExpression>();

        /// <summary>
        /// The parameter values
        /// </summary>
        readonly List<object> values = new List<object>();

        /// <summary>
        /// Parameterize the expression
        /// </summary>
        /// <param name="expression">The original expression</param>
        /// <param name="parameterExpressions">The parameterExpressions which are converted from ConstantExpression</param>
        /// <param name="paraValues">The parameter values</param>
        /// <returns>The parameterized expression</returns>
        public Expression Parameterize(Expression expression, out ParameterExpression[] parameterExpressions, out object[] paraValues)
        {
            expression = Visit(expression);
            paraValues = values.ToArray();
            parameterExpressions = parameters.ToArray();
            return expression;
        }

        /// <summary>
        /// Visit the constantExpression
        /// </summary>
        /// <param name="node">The original expression</param>
        /// <returns>The ParameterExpression</returns>
        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (ParameterizableTypes.ContainsKey(node.Type))
            {
                // Replace the constant expression to parameter expression and save the parameter value.
                var para = Expression.Parameter(node.Type, "para" + parameters.Count);
                parameters.Add(para);
                values.Add(node.Value);
                return para;
            }
            return base.VisitConstant(node);
        }
    }
}
