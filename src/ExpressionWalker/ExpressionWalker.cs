using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExpressionWalker
{
    public class ExpressionWalker : IObservable<ExpressionInfo>
    {
        private readonly List<IObserver<ExpressionInfo>> _observers = new List<IObserver<ExpressionInfo>>();
        private readonly IExpressionChecker[] _expressionCheckers;

        public ExpressionWalker()
        {
            _expressionCheckers = new IExpressionChecker[]
                {
                    new LambdaExpressionChecker(), 
                    new BinaryExpressionChecker(), 
                    new ParameterExpressionChecker(), 
                    new MethodCallExpressionChecker(), 
                    new ConstantExpressionChecker(), 
                    new UnaryExpressionChecker()
                };
        }

        public void Walk(Expression expression)
        {
            WalkInner(null, expression);
        }

        void WalkInner(IExpressionInfo parent, Expression expression)
        {
            var checker = _expressionCheckers.First(expressionChecker => expressionChecker.Check(expression));

            var current = new ExpressionInfo
                {
                    Depth = parent != null ? parent.Depth + 1 : 1,
                    ExpressionType = checker.ExpressionType, 
                    Parent = parent, 
                    Value = checker.Value
                };
            _observers.ForEach(o => o.OnNext(current));

            checker.Expressions.ToList().ForEach(exp => WalkInner(current, exp));
        }

        public IDisposable Subscribe(IObserver<ExpressionInfo> observer)
        {
            _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private readonly List<IObserver<ExpressionInfo>> _observers;
            private readonly IObserver<ExpressionInfo> _observer;

            public Unsubscriber(List<IObserver<ExpressionInfo>> observers, IObserver<ExpressionInfo> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}