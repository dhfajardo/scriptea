namespace scriptea.Tree.Expression.Operators.AssignmentOperators
{
    public class AssigRightZeroFillShiftOperatorNode:BaseAssigOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate() >>  RightNode.Evaluate();
        }
    }
}