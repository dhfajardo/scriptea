namespace scriptea.Tree.Expression.Operators
{
    public abstract class BaseUnaryOperatorNode:ExpressionNode
    {
        public ExpressionNode ValueNode { get; set; }
    }
}