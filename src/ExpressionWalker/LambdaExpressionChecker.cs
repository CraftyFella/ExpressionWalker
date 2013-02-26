using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionWalker
{
    internal class LambdaExpressionChecker : ExpressionCheckerBase<LambdaExpression>, IExpressionChecker
    {
        public bool Check(Expression expression)
        {
            var result = expression is LambdaExpression;
            if (result)
            {
                Expressions = new[] { (expression as LambdaExpression).Body };
                IncreaseDepth = true;
            }
            return result;
        }

        public IEnumerable<Expression> Expressions { get; private set; }
        public bool IncreaseDepth { get; private set; }
    }
}