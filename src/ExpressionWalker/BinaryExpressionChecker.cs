using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionWalker
{
    internal class BinaryExpressionChecker : ExpressionCheckerBase<BinaryExpression>, IExpressionChecker
    {
        public bool Check(Expression expression)
        {
            var result = expression is BinaryExpression;
            if (result)
            {
                Expressions = new[] { (expression as BinaryExpression).Left, (expression as BinaryExpression).Right };
                IncreaseDepth = true;
            }
            return result;
        }

        public IEnumerable<Expression> Expressions { get; private set; }
        public bool IncreaseDepth { get; private set; }
    }
}