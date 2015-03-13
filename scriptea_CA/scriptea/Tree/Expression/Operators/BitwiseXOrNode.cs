namespace scriptea.Tree.Expression.Operators
{
    public class BitwiseXOrNode:BinaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            return LeftNode.Evaluate(table) ^ RightNode.Evaluate(table);
        }
    }
}