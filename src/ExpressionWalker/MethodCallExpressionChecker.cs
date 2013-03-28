using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionWalker
{
    internal class MethodCallExpressionChecker : ExpressionCheckerBase<MethodCallExpression>, IExpressionChecker
    {
        protected override object GetValue()
        {
            return null;
        }

        protected override IEnumerable<Expression> Children
        {
            get { return Expression.Arguments; }
        }
    }
}