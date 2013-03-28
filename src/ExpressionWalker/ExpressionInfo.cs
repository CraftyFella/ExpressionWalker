namespace ExpressionWalker
{
    public class ExpressionInfo : IExpressionInfo
    {
        public int Depth { get; set; }

        public IExpressionInfo Parent { get; set; }

        public ExpressionTypes ExpressionType { get; set; }

        public object Value { get; set; }

        public override bool Equals(object obj)
        {
            var expressionInfo = obj as ExpressionInfo;
            return expressionInfo != null && expressionInfo.Equals(this);
        }

        bool Equals(ExpressionInfo expressionInfo)
        {
            return expressionInfo.Depth.Equals(this.Depth) &&
                   expressionInfo.ExpressionType.Equals(this.ExpressionType) &&
                   expressionInfo.Value == this.Value &&
                   expressionInfo.Parent == this.Parent;
        }
    }
}