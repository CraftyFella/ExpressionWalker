using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionWalker
{
    internal class ExpressionReader
    {
        private readonly Queue<Expression> _next = new Queue<Expression>();
        private readonly IEnumerable<IExpressionChecker> _expressionCheckers;

        public ExpressionReader()
        {
            Depth = 0;
        }

        public ExpressionReader(Expression expression)
        {
            _next.Enqueue(expression);
            _expressionCheckers = new IExpressionChecker[] {new LambdaExpressionChecker(), new BinaryExpressionChecker(), new ParameterExpressionChecker()};
        }

        public ExpressionTypes ExpressionType { get; private set; }

        public int Depth { get; private set; }

        public bool Read()
        {
            if (!_next.Any())
            {
                Depth = 0;
                ExpressionType = ExpressionTypes.None;
                return false;
            }

            var expression = _next.Dequeue();

            var checker = _expressionCheckers.First(expressionChecker => expressionChecker.Check(expression));
            checker.Expressions.ToList().ForEach(e => _next.Enqueue(e));
            ExpressionType = checker.ExpressionType;
            Depth += checker.IncreaseDepth ? 1 : 0;
            return true;
            
        }
    }
}