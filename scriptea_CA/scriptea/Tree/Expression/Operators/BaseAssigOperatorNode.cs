namespace scriptea.Tree.Expression.Operators
{
    public class BaseAssigOperatorNode:ExpressionNode
    {
        public /*IdNode*/ ExpressionNode LeftNode { get; set; }
        public ExpressionNode RightNode { get; set; }
    }
}