namespace scriptea.Tree.Expression.Operators.AssignmentOperators
{
    public class AssigBitwiseOrOperatorNode:BaseAssigOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate() | RightNode.Evaluate();
        }
    }
}