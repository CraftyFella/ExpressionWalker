using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionWalker
{
    internal class ConstantExpressionChecker : ExpressionCheckerBase<ConstantExpression>, IExpressionChecker
    {
        protected override IEnumerable<Expression> Children
        {
            get { yield break; }
        }
    }
}