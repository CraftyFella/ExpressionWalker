using FluentAssertions;
using Machine.Specifications;

namespace ExpressionWalker.Tests.ExpressionInfoSpecs
{
    public class When_two_expression_infos_are_different_instances
    {
        Establish context = () =>
            {
                _first = new ExpressionInfo();
                _second = new ExpressionInfo();
            };

        Because of = () => _result = _first.Equals(_second);

        It matches = () => _result.Should().BeTrue();

        private static ExpressionInfo _first;
        private static ExpressionInfo _second;
        private static bool _result;
    }
}