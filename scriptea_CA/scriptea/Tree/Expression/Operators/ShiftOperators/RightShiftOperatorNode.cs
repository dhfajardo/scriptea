namespace scriptea.Tree.Expression.Operators.ShiftOperators
{
    public class RightShiftOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            return LeftNode.Evaluate(table) >> RightNode.Evaluate(table);
        }
    }
}