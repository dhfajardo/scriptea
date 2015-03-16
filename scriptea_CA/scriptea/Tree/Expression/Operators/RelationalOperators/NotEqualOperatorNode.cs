namespace scriptea.Tree.Expression.Operators.RelationalOperators
{
    public class NotEqualOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            return ((LeftNode.GetType() != RightNode.GetType()) && (LeftNode.Evaluate(table) != RightNode.Evaluate(table)));
        }
    }
}