using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class TryNode:StatementNode
    {
        public IdNode ExceptionID { get; set; }
        public StatementNode TryCode { get; set; }
        public StatementNode CatchBlockCode { get; set; }
        public StatementNode FinallyCode { get; set; }
    }
}