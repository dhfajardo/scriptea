using System;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class ThrowNode:StatementNode
    {
        public ExpressionNode ThrowStatementNode { get; set; }
        public override void Interpret(SymbolTable table, FunctionTable functionTable)
        {
            throw (Exception)ThrowStatementNode.Evaluate(table);
        }
    }
}