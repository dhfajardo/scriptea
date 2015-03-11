namespace scriptea.Tree.Expression.Operators.RelationalOperators
{
    public class NotEquivOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate()
        {
            if (!LeftNode.Equals(RightNode) && LeftNode.Evaluate() != RightNode.Evaluate())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}