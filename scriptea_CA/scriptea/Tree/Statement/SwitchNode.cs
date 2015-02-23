using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class SwitchNode:ExpressionNode
    {
        public ExpressionNode AssignmentExpressionNode { get; set; }
        public ExpressionNode CaseBlockNode { get; set; }
    }
}