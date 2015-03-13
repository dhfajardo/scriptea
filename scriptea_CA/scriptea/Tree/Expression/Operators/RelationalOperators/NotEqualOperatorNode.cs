namespace scriptea.Tree.Expression.Operators.RelationalOperators
{
    public class NotEqualOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            return LeftNode.Evaluate(table) != RightNode.Evaluate(table);
        }
    }
}