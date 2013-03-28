namespace ExpressionWalker
{
    public interface IExpressionInfo
    {
        int Depth { get; }
        IExpressionInfo Parent { get; }
        ExpressionTypes ExpressionType { get; }
        object Value { get; }
    }
}