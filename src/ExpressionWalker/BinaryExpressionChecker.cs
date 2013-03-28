using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionWalker
{
    internal class BinaryExpressionChecker : ExpressionCheckerBase<BinaryExpression>, IExpressionChecker
    {
        protected override object GetValue()
        {
            return null;
        }

        protected override IEnumerable<Expression> Children
        {
            get
            {
                yield return Expression.Right;
                yield return Expression.Left;
            }
        }
    }
}