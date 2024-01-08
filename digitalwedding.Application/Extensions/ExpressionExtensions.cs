using System;
using System.Linq.Expressions;
using digitalwedding.Application.Data.Models.Repositories;

namespace digitalwedding.Application.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> Combine<T>(this Expression<Func<T, bool>> expression, Expression<Func<T, bool>> with, ParameterExpression parameter)
        {
            var leftVisitor = new ReplaceExpressionVisitor(expression.Parameters[0], parameter);
            var left = leftVisitor.Visit(expression.Body);

            var rightVisitor = new ReplaceExpressionVisitor(with.Parameters[0], parameter);
            var right = rightVisitor.Visit(with.Body);

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left, right), parameter);
        }


        private class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _oldValue;
            private readonly Expression _newValue;

            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public override Expression Visit(Expression node)
            {
                if (node == _oldValue)
                {
                    return _newValue;
                }
                return base.Visit(node);
            }
        }
    }
}

