namespace scriptea.Tree.Expression.Operators.AssignmentOperators
{
    public class AssigDivOperatorNode:BaseAssigOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate()/RightNode.Evaluate();
        }
    }
}