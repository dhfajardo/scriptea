using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class ContinueNode:StatementNode
    {
        public override void Interpret(SymbolTable table)
        {
            throw new ContinueException("");
        }
    }
}