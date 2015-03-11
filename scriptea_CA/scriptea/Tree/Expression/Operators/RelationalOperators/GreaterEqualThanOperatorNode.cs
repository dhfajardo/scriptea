namespace scriptea.Tree.Expression.Operators.RelationalOperators
{
    public class GreaterEqualThanOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate()
        {
            if (LeftNode.Evaluate() >= RightNode.Evaluate())
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