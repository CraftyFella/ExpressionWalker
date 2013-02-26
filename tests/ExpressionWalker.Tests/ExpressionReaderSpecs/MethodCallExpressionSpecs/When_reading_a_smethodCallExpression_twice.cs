using System;
using System.Linq.Expressions;
using FluentAssertions;
using Machine.Specifications;

namespace ExpressionWalker.Tests.ExpressionReaderSpecs.MethodCallExpressionSpecs
{
    public class When_reading_a_smethodCallExpression_twice
    {
        private Establish context = () =>
            {
                Expression<Action<int, int>> methodCallExpression = (x, y) => Console.WriteLine("x {0}, y{1}", x, y);
                _sut = new ExpressionReader(methodCallExpression);
                _sut.Read();
            };

        Because of = () => _result = _sut.Read();

        It should_succeed = () => _result.Should().BeTrue();

        It should_set_token_type_of_MethodCallExpression =
            () => _sut.ExpressionType.Should().Be(ExpressionTypes.MethodCallExpression);

        It should_set_depth_to_2 = () => _sut.Depth.Should().Be(2);
        It should_have_no_value = () => _sut.Value.Should().BeNull();

        static bool _result;
        static ExpressionReader _sut;
    }
}