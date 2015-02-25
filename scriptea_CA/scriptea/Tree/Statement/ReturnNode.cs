using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class ReturnNode:StatementNode
    {
        public ExpressionNode ExpressionOptNode { get; set; }
    }
}