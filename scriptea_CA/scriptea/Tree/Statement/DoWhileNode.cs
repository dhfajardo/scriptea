using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class DoWhileNode:StatementNode
    {
        public StatementNode Code { get; set; }
        public ExpressionNode AssignmentNode { get; set; }
    }
}