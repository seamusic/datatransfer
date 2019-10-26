using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq.Expressions
{
    /// <summary>
    /// 表示表达式树的扩展。
    /// </summary>
    public static class ExpressionExs
    {
        internal class Assigner<T>
        {
            public static T Assign(ref T left, T right)
            {
                return (left = right);
            }
        }
        private static readonly Type AssignerType = typeof(Assigner<>);

        /// <summary>
        /// 创建一个表示赋值运算的 <see cref="System.Linq.Expressions.BinaryExpression"/>。
        /// </summary>
        /// <param name="left">要将 <see cref="System.Linq.Expressions.BinaryExpression.Left"/> 属性设置为与其相等的 <see cref="System.Linq.Expressions.Expression"/>。</param>
        /// <param name="right">要将 <see cref="System.Linq.Expressions.BinaryExpression.Right"/> 属性设置为与其相等的 <see cref="System.Linq.Expressions.Expression"/>。</param>
        /// <returns>一个 <see cref="System.Linq.Expressions.BinaryExpression"/>，其 <see cref="System.Linq.Expressions.BinaryExpression.Left"/> 和 <see cref="System.Linq.Expressions.BinaryExpression.Right"/> 属性设置为指定值。</returns>
        public static BinaryExpression Assign(Expression left, Expression right)
        {
            var assign = AssignerType.MakeGenericType(left.Type).GetMethod("Assign");

            var assignExpr = Expression.Add(left, right, assign);

            return assignExpr;
        }

    }
}
