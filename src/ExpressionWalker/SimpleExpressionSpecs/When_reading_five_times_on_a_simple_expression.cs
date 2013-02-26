using System;
using System.Linq.Expressions;
using FluentAssertions;
using Machine.Specifications;

namespace ExpressionWalker.SimpleExpressionSpecs
{
    public class When_reading_five_times_on_a_simple_expression
    {
        private Establish context = () =>
            {
                Expression<Func<int, int>> simpleExpression = x => x * x;
                _sut = new ExpressionReader(simpleExpression);
                _sut.Read();
                _sut.Read();
                _sut.Read();
                _sut.Read();
            };

        private Because of = () => _result = _sut.Read();

        private It should_fail = () => _result.Should().BeFalse();
        private It should_set_token_type_of_none = () => _sut.ExpressionType.Should().Be(ExpressionTypes.None);
        private It should_set_depth_to_0 = () => _sut.Depth.Should().Be(0);

        private static bool _result;
        private static ExpressionReader _sut;
    }
}