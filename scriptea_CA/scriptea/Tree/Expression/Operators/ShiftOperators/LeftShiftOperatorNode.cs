namespace scriptea.Tree.Expression.Operators.ShiftOperators
{
    public class LeftShiftOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            return LeftNode.Evaluate(table) << RightNode.Evaluate(table);
        }
    }
}