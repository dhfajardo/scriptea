namespace scriptea.Tree.Expression.Operators.AssignmentOperators
{
    public class AssigMulOperatorNode:BaseAssigOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate()*RightNode.Evaluate();
        }
    }
}