using FluentAssertions;
using Machine.Fakes;
using Machine.Specifications;

namespace ExpressionWalker.Tests.ConsoleWriterObserverSpecs
{
    public class When_observing_an_expression_info : WithSubject<ConsoleWriterObserver>
    {
        Establish context = () =>
            {
                _first = new ExpressionInfo();
            };

        Because of = () => Subject.OnNext(_first);

        It writes_expression_type = () => The<IWriter>().WasToldTo(x => x.Write(_first));

        private static ExpressionInfo _first;
    }
}