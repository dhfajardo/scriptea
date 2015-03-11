namespace scriptea.Tree.Expression.Operators.RelationalOperators
{
    public class GreaterThanOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate()
        {
            if (LeftNode.Evaluate() > RightNode.Evaluate())
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