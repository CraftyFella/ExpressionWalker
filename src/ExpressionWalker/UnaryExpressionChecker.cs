using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionWalker
{
    internal class UnaryExpressionChecker : ExpressionCheckerBase<UnaryExpression>, IExpressionChecker
    {
        protected override object GetValue()
        {
            return null;
        }

        protected override IEnumerable<Expression> Children
        {
            get { yield return Expression.Operand; }
        }
    }
}