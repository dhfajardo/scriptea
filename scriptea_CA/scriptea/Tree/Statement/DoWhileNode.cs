using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class DoWhileNode:ExpressionNode
    {
        public ExpressionNode StatementNode { get; set; }
        public ExpressionNode AssignmentNode { get; set; }
    }
}