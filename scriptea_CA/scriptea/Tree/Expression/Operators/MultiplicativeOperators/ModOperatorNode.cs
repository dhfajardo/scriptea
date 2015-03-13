namespace scriptea.Tree.Expression.Operators.MultiplicativeOperators
{
    public class ModOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            return LeftNode.Evaluate(table)%RightNode.Evaluate(table);
        }
    }
}