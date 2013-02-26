using System;
using System.Linq.Expressions;
using FluentAssertions;
using Machine.Specifications;

namespace ExpressionWalker.SimpleExpressionSpecs
{
    public class When_reading_four_times_on_a_simple_expression
    {
        private Establish context = () =>
            {
                Expression<Func<int, int>> simpleExpression = x => x * x;
                _sut = new ExpressionReader(simpleExpression);
                _sut.Read();
                _sut.Read();
                _sut.Read();
            };

        private Because of = () => _result = _sut.Read();

        private It should_succeed = () => _result.Should().BeTrue();

        private It should_set_token_type_of_parameter_expression =
            () => _sut.ExpressionType.Should().Be(ExpressionTypes.ParameterExpression);

        private It should_set_depth_to_2 = () => _sut.Depth.Should().Be(2);

        private static bool _result;
        private static ExpressionReader _sut;
    }
}