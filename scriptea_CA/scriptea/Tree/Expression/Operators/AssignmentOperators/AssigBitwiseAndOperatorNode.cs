namespace scriptea.Tree.Expression.Operators.AssignmentOperators
{
    public class AssigBitwiseAndOperatorNode:BaseAssigOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate() & RightNode.Evaluate();
        }
    }
}