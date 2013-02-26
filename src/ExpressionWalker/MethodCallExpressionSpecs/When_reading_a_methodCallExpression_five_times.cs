using System;
using System.Linq.Expressions;
using FluentAssertions;
using Machine.Specifications;

namespace ExpressionWalker.MethodCallExpressionSpecs
{
    public class When_reading_a_methodCallExpression_five_times
    {
        private Establish context = () =>
            {
                Expression<Action<int, int>> methodCallExpression = (x, y) => Console.WriteLine("x {0}, y{1}", x, y);
                _sut = new ExpressionReader(methodCallExpression);
                _sut.Read();
                _sut.Read();
                _sut.Read();
                _sut.Read();
            };

        Because of = () => _result = _sut.Read();

        It should_succeed = () => _result.Should().BeTrue();

        It should_set_token_type_of_UnaryExpression = () => _sut.ExpressionType.Should().Be(ExpressionTypes.UnaryExpression);

        It should_set_depth_to_4 = () => _sut.Depth.Should().Be(4);

        static bool _result;
        static ExpressionReader _sut;
    }
}