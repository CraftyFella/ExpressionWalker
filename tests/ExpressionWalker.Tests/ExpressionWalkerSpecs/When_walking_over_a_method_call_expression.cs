using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FluentAssertions;
using Machine.Specifications;

namespace ExpressionWalker.Tests.ExpressionWalkerSpecs
{
    public class When_walking_over_a_method_call_expression
    {
        Establish context = () =>
            {
                _methodCallExpression = (x, y) => Console.WriteLine("x {0}, y{1}", x, y);
                _sut = new ExpressionWalker();

                Action<ExpressionInfo> action = x => Expressions.Add(x);
                _sut.Subscribe(action);
            };

        Because of = () => _sut.Walk(_methodCallExpression);

        It should_return_all_expressions = () => Expressions.Should().HaveCount(7);
        It should_have_first_expression_as_lambda = () => Expressions[0].ShouldBeEquivalentTo(new ExpressionInfo { Depth = 1, ExpressionType = ExpressionTypes.LambdaExpression }, options => options.Excluding(o => o.Parent));
        It should_have_second_expression_as_method_call = () => Expressions[1].ShouldBeEquivalentTo(new ExpressionInfo { Depth = 2, ExpressionType = ExpressionTypes.MethodCallExpression }, options => options.Excluding(o => o.Parent));
        It should_have_third_expression_as_constant = () => Expressions[2].ShouldBeEquivalentTo(new ExpressionInfo { Depth = 3, ExpressionType = ExpressionTypes.ConstantExpression, Value = "x {0}, y{1}" }, options => options.Excluding(o => o.Parent));
        It should_have_fourth_expression_as_unary = () => Expressions[3].ShouldBeEquivalentTo(new ExpressionInfo { Depth = 3, ExpressionType = ExpressionTypes.UnaryExpression }, options => options.Excluding(o => o.Parent));
        It should_have_fifth_expression_as_parameter = () => Expressions[4].ShouldBeEquivalentTo(new ExpressionInfo { Depth = 4, ExpressionType = ExpressionTypes.ParameterExpression, Value = "x" }, options => options.Excluding(o => o.Parent));
        It should_have_sixth_expression_as_unary = () => Expressions[5].ShouldBeEquivalentTo(new ExpressionInfo { Depth = 3, ExpressionType = ExpressionTypes.UnaryExpression }, options => options.Excluding(o => o.Parent));
        It should_have_seventh_expression_as_parameter = () => Expressions[6].ShouldBeEquivalentTo(new ExpressionInfo { Depth = 4, ExpressionType = ExpressionTypes.ParameterExpression, Value = "y" }, options => options.Excluding(o => o.Parent));

        static ExpressionWalker _sut;
        static Expression<Action<int, int>> _methodCallExpression;
        static readonly List<ExpressionInfo> Expressions = new List<ExpressionInfo>();
    }
}