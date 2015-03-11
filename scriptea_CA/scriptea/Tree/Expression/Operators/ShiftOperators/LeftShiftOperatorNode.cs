namespace scriptea.Tree.Expression.Operators.ShiftOperators
{
    public class LeftShiftOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate() << RightNode.Evaluate();
        }
    }
}