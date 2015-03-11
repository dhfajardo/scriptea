namespace scriptea.Tree.Expression.Operators
{
    public abstract class BaseAssigOperatorNode:ExpressionNode
    {
        public /*IdNode*/ ExpressionNode LeftNode { get; set; }
        public ExpressionNode RightNode { get; set; }
    }
}