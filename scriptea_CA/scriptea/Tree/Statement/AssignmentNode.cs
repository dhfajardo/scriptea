using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class AssignmentNode:StatementNode
    {
        public ExpressionNode AssignmentExpressionNode { get; set; }
    }
}