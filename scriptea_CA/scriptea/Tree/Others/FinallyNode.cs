using System.Collections.Generic;
using scriptea.Tree.Expression;
using scriptea.Tree.Statement;

namespace scriptea.Tree.Others
{
    public class FinallyNode:StatementNode
    {
        public List<StatementNode> FinallyCode { get; set; }
        public override void Interpret(SymbolTable table, FunctionTable functionTable)
        {
            foreach (var statementNode in FinallyCode)
            {
                statementNode.Interpret(table, functionTable);
            } 
        }
    }
}