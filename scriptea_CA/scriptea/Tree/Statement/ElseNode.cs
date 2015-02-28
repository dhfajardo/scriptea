using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class ElseNode:StatementNode
    {
        public StatementNode CodeNode { get; set; }
    }
}