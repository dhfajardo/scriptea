using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class ElseNode:StatementNode
    {
        public List<StatementNode> CodeNode { get; set; }
        public override void Interpret(SymbolTable table, FunctionTable functionTable)
        {
            if (CodeNode != null)
            {
                foreach (var statemenNode in CodeNode)
                {
                    statemenNode.Interpret(table, functionTable);
                }
            }
        }
    }
}