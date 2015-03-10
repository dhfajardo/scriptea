using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class TryNode:StatementNode
    {
        public IdNode ExceptionID { get; set; }
        public List<StatementNode> TryCode { get; set; }
        public StatementNode CatchBlockCode { get; set; }
        public StatementNode FinallyCode { get; set; }
    }
}