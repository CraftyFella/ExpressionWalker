using System;
using System.Linq.Expressions;
using FluentAssertions;
using Machine.Specifications;

namespace ExpressionWalker.SimpleExpressionSpecs
{
    public class When_reading_five_times_on_a_simple_expression
    {
        Establish context = () =>
            {
                Expression<Func<int, int>> simpleExpression = x => x * x;
                _sut = new ExpressionReader(simpleExpression);
                _sut.Read();
                _sut.Read();
                _sut.Read();
                _sut.Read();
            };

        Because of = () => _result = _sut.Read();

        It should_fail = () => _result.Should().BeFalse();
        It should_set_token_type_of_none = () => _sut.ExpressionType.Should().Be(ExpressionTypes.None);
        It should_set_depth_to_0 = () => _sut.Depth.Should().Be(0);
        It should_have_no_value = () => _sut.Value.Should().BeNull();

        static bool _result;
        static ExpressionReader _sut;
    }
}