namespace scriptea.Tree.Expression.Operators.ShiftOperators
{
    public class RightShiftZeroFillOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate()
        {
            return (int)((uint)LeftNode.Evaluate() >> RightNode.Evaluate());
        }
    }
}