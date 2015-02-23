using scriptea.Tree.Expression;

namespace scriptea.Tree.Others
{
    public class CaseNode:ExpressionNode
    {
        public ExpressionNode AssignmentExpressionNode { get; set; }
        public ExpressionNode StatementListNode { get; set; }
    }
}