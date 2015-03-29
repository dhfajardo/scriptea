using System.Collections.Generic;
using scriptea.Tree.Expression;
using scriptea.Tree.Statement;

namespace scriptea.Tree.Others
{
    public class FunctionDeclarationNode:StatementNode
    {
        public /*IdNode*/ string Id { get; set; }
        public List<IdNode> ParameterList { get; set; }
        public List<StatementNode> Statements { get; set; }
        public override void Interpret(SymbolTable table, FunctionTable functionTable)
        {
            //throw new System.NotImplementedException();
            foreach (var idNode in ParameterList)
            {
                idNode.Evaluate(table);
            }
            foreach (var statementNode in Statements)
            {
                statementNode.Interpret(table, functionTable);
            }
        }
    }
}