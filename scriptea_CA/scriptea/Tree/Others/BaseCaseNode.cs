using scriptea.Tree.Expression;

namespace scriptea.Tree.Others
{
    public class BaseCaseNode
    {
        public ExpressionNode StatementListNode { get; set; }
        public BaseCaseNode NextCase { get; set; }
    }
}