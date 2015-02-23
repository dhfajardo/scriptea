using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class ElseNode:ExpressionNode
    {
        public ExpressionNode StatementNode { get; set; }
    }
}