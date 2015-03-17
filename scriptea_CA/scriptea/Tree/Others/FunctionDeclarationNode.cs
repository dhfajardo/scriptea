using System.Collections.Generic;
using scriptea.Tree.Expression;
using scriptea.Tree.Statement;

namespace scriptea.Tree.Others
{
    public class FunctionDeclarationNode:StatementNode
    {
        public IdNode Id { get; set; }
        public List<IdNode> ParameterList { get; set; }
        public List<StatementNode> Statements { get; set; }
        public override void Interpret(SymbolTable table)
        {
            throw new System.NotImplementedException();
        }
    }
}