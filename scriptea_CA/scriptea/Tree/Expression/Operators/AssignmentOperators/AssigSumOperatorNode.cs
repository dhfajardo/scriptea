namespace scriptea.Tree.Expression.Operators.AssignmentOperators
{
    public class AssigSumOperatorNode:BaseAssigOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate() + RightNode.Evaluate();
        }
    }
}