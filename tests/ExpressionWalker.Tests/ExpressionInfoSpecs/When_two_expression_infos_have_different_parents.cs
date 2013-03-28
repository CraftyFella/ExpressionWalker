using FluentAssertions;
using Machine.Specifications;

namespace ExpressionWalker.Tests.ExpressionInfoSpecs
{
    public class When_two_expression_infos_have_different_parents
    {
        Establish context = () =>
            {
                _first = new ExpressionInfo { Parent = new ExpressionInfo()};
                _second = new ExpressionInfo { Parent = null };
            };

        Because of = () => _result = _first.Equals(_second);

        It doesnt_match = () => _result.Should().BeFalse();

        private static ExpressionInfo _first;
        private static ExpressionInfo _second;
        private static bool _result;
    }
}