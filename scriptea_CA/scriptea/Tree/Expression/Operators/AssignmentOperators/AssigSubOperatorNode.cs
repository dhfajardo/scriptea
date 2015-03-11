namespace scriptea.Tree.Expression.Operators.AssignmentOperators
{
    public class AssigSubOperatorNode:BaseAssigOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate() - RightNode.Evaluate();
        }
    }
}