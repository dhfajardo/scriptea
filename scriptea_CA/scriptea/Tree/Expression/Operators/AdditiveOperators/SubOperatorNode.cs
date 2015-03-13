namespace scriptea.Tree.Expression.Operators.AdditiveOperators
{
    public class SubOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            return LeftNode.Evaluate(table) - RightNode.Evaluate(table);
        }
    }
}