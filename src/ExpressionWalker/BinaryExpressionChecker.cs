using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionWalker
{
    internal class BinaryExpressionChecker : ExpressionCheckerBase<BinaryExpression>, IExpressionChecker
    {
        protected override IEnumerable<Expression> Children
        {
            get
            {
                yield return Expression.Left;
                yield return Expression.Right;
            }
        }
    }
}