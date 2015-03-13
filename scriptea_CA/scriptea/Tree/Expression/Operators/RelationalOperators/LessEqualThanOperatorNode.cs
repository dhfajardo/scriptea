namespace scriptea.Tree.Expression.Operators.RelationalOperators
{
    public class LessEqualThanOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            return LeftNode.Evaluate(table) <= RightNode.Evaluate(table);
        }
    }
}