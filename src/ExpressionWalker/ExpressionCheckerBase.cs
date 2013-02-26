using System;
using System.Linq.Expressions;

namespace ExpressionWalker
{
    internal class ExpressionCheckerBase<TExpression> where TExpression : Expression
    {
        public ExpressionTypes ExpressionType { get { return (ExpressionTypes)Enum.Parse(typeof (ExpressionTypes), typeof (TExpression).Name, true); } }
    }
}