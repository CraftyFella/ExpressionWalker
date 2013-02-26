using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionWalker
{
    internal interface IExpressionChecker
    {
        bool Check(Expression expression);
        IEnumerable<Expression> Expressions { get; }
        bool IncreaseDepth { get; }
        ExpressionTypes ExpressionType { get; }
    }
}