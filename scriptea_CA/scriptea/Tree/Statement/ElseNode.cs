using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class ElseNode:StatementNode
    {
        public List<StatementNode> CodeNode { get; set; }
        public override void Interpret(SymbolTable table)
        {
            if (CodeNode != null)
            {
                foreach (var statemenNode in CodeNode)
                {
                    statemenNode.Interpret(table);
                }
            }
        }
    }
}