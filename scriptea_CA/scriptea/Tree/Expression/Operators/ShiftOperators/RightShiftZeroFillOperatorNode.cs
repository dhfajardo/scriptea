namespace scriptea.Tree.Expression.Operators.ShiftOperators
{
    public class RightShiftZeroFillOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            return (int)((uint)LeftNode.Evaluate(table) >> RightNode.Evaluate(table));
        }
    }
}