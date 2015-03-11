namespace scriptea.Tree.Expression.Operators.ShiftOperators
{
    public class RightShiftOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate() >> RightNode.Evaluate();
        }
    }
}