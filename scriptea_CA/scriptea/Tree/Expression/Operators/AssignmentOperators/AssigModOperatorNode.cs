namespace scriptea.Tree.Expression.Operators.AssignmentOperators
{
    public class AssigModOperatorNode:BaseAssigOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate() % RightNode.Evaluate();
        }
    }
}