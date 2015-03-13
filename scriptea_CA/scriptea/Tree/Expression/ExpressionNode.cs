namespace scriptea.Tree.Expression
{
    public abstract class ExpressionNode
    {
        public abstract dynamic Evaluate(SymbolTable table);
    }
}
