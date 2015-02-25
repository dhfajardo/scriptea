using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{   
    public class ForNode:StatementNode
    {
        public ExpressionNode ForConditions { get; set; }
        public ExpressionNode StatementNode { get; set; }
    }
}