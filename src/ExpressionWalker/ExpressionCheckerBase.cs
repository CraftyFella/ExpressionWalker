using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionWalker
{
    internal abstract class ExpressionCheckerBase<TExpression> where TExpression : Expression
    {
        protected readonly List<Expression> _expressions = new List<Expression>();
        public IEnumerable<Expression> Expressions { get { return _expressions; } }
        public ExpressionTypes ExpressionType { get { return (ExpressionTypes)Enum.Parse(typeof (ExpressionTypes), typeof (TExpression).Name, true); } }
        public bool IncreaseDepth { get { return _expressions.Any(); } }
        private Expression _expression = null;

        public bool Check(Expression expression)
        {
            _expression = expression;
            _expressions.Clear();
            if (Expression != null)
            {
                _expressions.AddRange(Children);
                Value = GetValue();
                return true;
            }
            return false;
        }

        protected abstract object GetValue();

        public object Value { get; private set; }

        protected TExpression Expression
        {
            get { return _expression as TExpression; }
        }

        protected abstract IEnumerable<Expression> Children { get; }
    }
}