using System;
using System.Linq.Expressions;
using FluentAssertions;
using Machine.Specifications;

namespace ExpressionWalker.SimpleExpressionSpecs
{

    public class When_reading_a_simple_expression
    {
        private Establish context = () =>
            {
                Expression<Func<int, int>> simpleExpression = x => x * x;
                _sut = new ExpressionReader(simpleExpression);
            };

        private Because of = () => _result = _sut.Read();

        private It should_succeed = () => _result.Should().BeTrue();

        private It should_set_token_type_of_lambda_expression =
            () => _sut.ExpressionType.Should().Be(ExpressionTypes.LambdaExpression);

        private It should_set_depth_to_1 = () => _sut.Depth.Should().Be(1);

        private static bool _result;
        private static ExpressionReader _sut;
    }
}