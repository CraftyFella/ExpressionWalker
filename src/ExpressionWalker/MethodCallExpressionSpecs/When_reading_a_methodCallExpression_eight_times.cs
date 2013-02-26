using System;
using System.Linq.Expressions;
using FluentAssertions;
using Machine.Specifications;

namespace ExpressionWalker.MethodCallExpressionSpecs
{
    public class When_reading_a_methodCallExpression_eight_times
    {
        private Establish context = () =>
            {
                Expression<Action<int, int>> methodCallExpression = (x, y) => Console.WriteLine("x {0}, y{1}", x, y);
                _sut = new ExpressionReader(methodCallExpression);
                _sut.Read();
                _sut.Read();
                _sut.Read();
                _sut.Read();
                _sut.Read();
                _sut.Read();
                _sut.Read();
            };

        Because of = () => _result = _sut.Read();

        It should_fail = () => _result.Should().BeFalse();

        It should_set_token_type_of_None = () => _sut.ExpressionType.Should().Be(ExpressionTypes.None);

        It should_set_depth_to_0 = () => _sut.Depth.Should().Be(0);
        It should_have_no_value = () => _sut.Value.Should().BeNull();
        static bool _result;
        static ExpressionReader _sut;
    }
}