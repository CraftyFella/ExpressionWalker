using System;

namespace ExpressionWalker
{
    public class ConsoleWriterObserver :  IObserver<ExpressionInfo>
    {
        private readonly IWriter _writer;

        public ConsoleWriterObserver(IWriter writer)
        {
            _writer = writer;
        }

        public void OnNext(ExpressionInfo value)
        {
            _writer.Write(value);
        }

        public void OnError(Exception error)
        {
            
        }

        public void OnCompleted()
        {
            
        }
    }
}