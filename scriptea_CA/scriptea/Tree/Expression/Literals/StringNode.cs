namespace scriptea.Tree.Expression.Literals
{
    public class StringNode:ExpressionNode
    {
        public string Value { get; set; }
        public override dynamic Evaluate(SymbolTable table)
        {
            return Value;
        }
    }
}