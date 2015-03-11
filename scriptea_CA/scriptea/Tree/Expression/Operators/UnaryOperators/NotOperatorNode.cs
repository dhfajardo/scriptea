namespace scriptea.Tree.Expression.Operators.UnaryOperators
{
    public class NotOperatorNode:BaseUnaryOperatorNode
    {
        public override dynamic Evaluate()
        {
            return !ValueNode.Evaluate();
        }
    }
}