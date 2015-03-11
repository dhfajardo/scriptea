namespace scriptea.Tree.Expression.Operators.AssignmentOperators
{
    public class AssigLeftShiftOperatorNode:BaseAssigOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate() << RightNode.Evaluate();
        }
    }
}