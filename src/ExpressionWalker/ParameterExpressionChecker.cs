using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionWalker
{
    internal class ParameterExpressionChecker : ExpressionCheckerBase<ParameterExpression>, IExpressionChecker
    {
        public bool Check(Expression expression)
        {
            var result = expression is ParameterExpression;
            if (result)
            {
                Expressions = new Expression[0];
                IncreaseDepth = false;
            }
            return result;
        }

        public IEnumerable<Expression> Expressions { get; private set; }
        public bool IncreaseDepth { get; private set; }
    }
}