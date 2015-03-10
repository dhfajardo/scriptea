using System.Collections.Generic;
using scriptea.Tree.Expression;
using scriptea.Tree.Statement;

namespace scriptea.Tree.Others
{
    public class FinallyNode:StatementNode
    {
        public List<StatementNode> FinallyCode { get; set; }
    }
}