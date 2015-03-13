namespace scriptea.Tree.Expression.Operators.RelationalOperators
{
    public class EqualOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            return ((LeftNode.GetType() == RightNode.GetType()) && (LeftNode.Evaluate(table) == RightNode.Evaluate(table)));
        }
    }
}