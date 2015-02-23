using scriptea.Tree.Expression;

namespace scriptea.Tree.Others
{
    public class CatchNode:ExpressionNode
    {
        public string ID { get; set; }
        public ExpressionNode CompoundStatementNode { get; set; }
    }
}