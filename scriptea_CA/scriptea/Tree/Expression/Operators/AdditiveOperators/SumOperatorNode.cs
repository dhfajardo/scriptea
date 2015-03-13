namespace scriptea.Tree.Expression.Operators.AdditiveOperators
{
    public class SumOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            return LeftNode.Evaluate(table) + RightNode.Evaluate(table);
        }
    }
}