using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionWalker
{
    internal class ParameterExpressionChecker : ExpressionCheckerBase<ParameterExpression>, IExpressionChecker
    {
        protected override object GetValue()
        {
            return Expression.Name;
        }

        protected override IEnumerable<Expression> Children
        {
            get { yield break; }
        }
    }
}