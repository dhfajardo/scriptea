namespace scriptea.Tree.Expression.Operators.AssignmentOperators
{
    public class AssigBitwiseXOrOperatorNode:BaseAssigOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate() ^ RightNode.Evaluate();
        }
    }
}