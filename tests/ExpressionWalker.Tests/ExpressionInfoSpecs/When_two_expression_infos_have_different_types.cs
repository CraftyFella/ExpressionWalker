using FluentAssertions;
using Machine.Specifications;

namespace ExpressionWalker.Tests.ExpressionInfoSpecs
{
    public class When_two_expression_infos_have_different_types
    {
        Establish context = () =>
            {
                _first = new ExpressionInfo {ExpressionType = ExpressionTypes.LambdaExpression};
                _second = new ExpressionInfo {ExpressionType = ExpressionTypes.MethodCallExpression};
            };

        Because of = () => _result = _first.Equals(_second);

        It doesnt_match = () => _result.Should().BeFalse();

        private static ExpressionInfo _first;
        private static ExpressionInfo _second;
        private static bool _result;
    }
}