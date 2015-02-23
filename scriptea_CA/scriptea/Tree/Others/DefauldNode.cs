using scriptea.Tree.Expression;

namespace scriptea.Tree.Others
{
    public class DefauldNode:ExpressionNode
    {
        public ExpressionNode StatementNode { get; set; }
        public ExpressionNode CaseClauseListNode { get; set; }
    }
}