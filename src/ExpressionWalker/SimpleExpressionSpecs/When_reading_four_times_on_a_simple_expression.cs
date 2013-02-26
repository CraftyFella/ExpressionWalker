using System;
using System.Linq.Expressions;
using FluentAssertions;
using Machine.Specifications;

namespace ExpressionWalker.SimpleExpressionSpecs
{
    public class When_reading_four_times_on_a_simple_expression
    {
        Establish context = () =>
            {
                Expression<Func<int, int>> simpleExpression = x => x * x;
                _sut = new ExpressionReader(simpleExpression);
                _sut.Read();
                _sut.Read();
                _sut.Read();
            };

        Because of = () => _result = _sut.Read();

        It should_succeed = () => _result.Should().BeTrue();

        It should_set_token_type_of_parameter_expression =
            () => _sut.ExpressionType.Should().Be(ExpressionTypes.ParameterExpression);

        It should_set_depth_to_2 = () => _sut.Depth.Should().Be(2);
        It should_have_value_x = () => _sut.Value.Should().Be("x");

        static bool _result;
        static ExpressionReader _sut;
    }
}