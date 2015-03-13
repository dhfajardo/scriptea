namespace scriptea.Tree.Expression.Literals
{
    public class IntegerNode:ExpressionNode
    {
        public int Value { get; set; }
        public override dynamic Evaluate(SymbolTable table)
        {
            return Value;
        }
    }
}
