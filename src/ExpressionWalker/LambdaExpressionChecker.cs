using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionWalker
{
    internal class LambdaExpressionChecker : ExpressionCheckerBase<LambdaExpression>, IExpressionChecker
    {
        protected override object GetValue()
        {
            return null;
        }

        protected override IEnumerable<Expression> Children
        {
            get { yield return Expression.Body; }
        }
    }
}