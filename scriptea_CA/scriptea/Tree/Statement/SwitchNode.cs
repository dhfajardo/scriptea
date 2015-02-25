using scriptea.Tree.Expression;
using scriptea.Tree.Others;

namespace scriptea.Tree.Statement
{
    public class SwitchNode:StatementNode
    {
        public ExpressionNode AssignmentExpressionNode { get; set; }
        public BaseCaseNode CaseBlockNode { get; set; }
    }
}