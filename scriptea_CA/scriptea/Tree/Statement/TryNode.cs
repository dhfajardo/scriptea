using System.Collections.Generic;
using scriptea.Tree.Expression;
using scriptea.Tree.Others;

namespace scriptea.Tree.Statement
{
    public class TryNode:StatementNode
    {
        public IdNode ExceptionID { get; set; }
        public List<StatementNode> TryCode { get; set; }
        public StatementNode CatchBlockCode { get; set; }
        public StatementNode FinallyCode { get; set; }
        public override void Interpret(SymbolTable table, FunctionTable functionTable)
        {
            try
            {
                foreach (var statementNode in TryCode)
                {
                    statementNode.Interpret(table, functionTable);
                }
            }
            catch (System.Exception e)
            {
                table.AddSymbol(ExceptionID.Name,e);
                var _catch = (CatchNode) CatchBlockCode;
                _catch.Interpret(table, functionTable);
            }
            var _finally = (FinallyNode) FinallyCode;
            if (_finally.FinallyCode!=null)
            {
                _finally.Interpret(table, functionTable);
            }
        }
    }
}