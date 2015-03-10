using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class ElseNode:StatementNode
    {
        public List<StatementNode> CodeNode { get; set; }
    }
}