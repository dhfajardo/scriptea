namespace scriptea.Tree.Expression.Operators.UnaryOperators
{
    public class NotOperatorNode:BaseUnaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            return !ValueNode.Evaluate(table);
        }
    }
}