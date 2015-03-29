using System.Collections.Generic;
using scriptea.Tree.Expression;
using scriptea.Tree.Statement;

namespace scriptea.Tree.Others
{
    public class CatchNode:StatementNode
    {
        public IdNode Id { get; set; }
        public List<StatementNode> CodeCatch { get; set; }
        public override void Interpret(SymbolTable table, FunctionTable functionTable)
        {
            foreach (var statementNode in CodeCatch)
            {
                statementNode.Interpret(table, functionTable);
            }
        }
    }
}