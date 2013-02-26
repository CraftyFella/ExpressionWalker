using System;
using System.Linq.Expressions;
using FluentAssertions;
using Machine.Specifications;

namespace ExpressionWalker.MethodCallExpressionSpecs
{

    public class When_reading_a_methodCallExpression
    {
        Establish context = () =>
            {
                Expression<Action<int, int>> methodCallExpression = (x, y) => Console.WriteLine("x {0}, y{1}", x, y);
                _sut = new ExpressionReader(methodCallExpression);
            };

        Because of = () => _result = _sut.Read();

        It should_succeed = () => _result.Should().BeTrue();

        It should_set_token_type_of_LambdaExpression =
            () => _sut.ExpressionType.Should().Be(ExpressionTypes.LambdaExpression);

        It should_set_depth_to_1 = () => _sut.Depth.Should().Be(1);

        static bool _result;
        static ExpressionReader _sut;
    }
}