namespace scriptea.Tree.Expression.Operators.AssignmentOperators
{
    public class AssigRightShiftOperatorNode:BaseAssigOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate() >> RightNode.Evaluate();
        }
    }
}