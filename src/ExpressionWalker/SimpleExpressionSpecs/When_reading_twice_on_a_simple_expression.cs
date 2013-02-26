using System;
using System.Linq.Expressions;
using FluentAssertions;
using Machine.Specifications;

namespace ExpressionWalker.SimpleExpressionSpecs
{
    public class When_reading_twice_on_a_simple_expression
    {
        Establish context = () =>
            {
                Expression<Func<int, int>> simpleExpression = x => x * x;
                _sut = new ExpressionReader(simpleExpression);
                _sut.Read();
            };

        Because of = () => _result = _sut.Read();

        It should_succeed = () => _result.Should().BeTrue();

        It should_set_token_type_of_binary_expression =
            () => _sut.ExpressionType.Should().Be(ExpressionTypes.BinaryExpression);

        It should_set_depth_to_2 = () => _sut.Depth.Should().Be(2);
        It should_have_no_value = () => _sut.Value.Should().BeNull();

        static bool _result;
        static ExpressionReader _sut;
    }
}