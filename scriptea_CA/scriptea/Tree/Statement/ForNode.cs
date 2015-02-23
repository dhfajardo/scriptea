using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{   
    public class ForNode:ExpressionNode
    {
        public ExpressionNode ForConditions { get; set; }
        public ExpressionNode StatementNode { get; set; }
    }
}