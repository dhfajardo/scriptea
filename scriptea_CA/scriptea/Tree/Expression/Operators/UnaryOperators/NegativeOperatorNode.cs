namespace scriptea.Tree.Expression.Operators.UnaryOperators
{
    public class NegativeOperatorNode:BaseUnaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            return ValueNode.Evaluate(table)*-1;
        }
    }
}