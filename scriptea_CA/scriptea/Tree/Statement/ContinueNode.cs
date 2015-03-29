using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class ContinueNode:StatementNode
    {
        public override void Interpret(SymbolTable table, FunctionTable functionTable)
        {
            throw new ContinueException("");
        }
    }
}