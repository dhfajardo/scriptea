namespace scriptea.Tree.Expression.Operators.MultiplicativeOperators
{
    public class DivOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            return LeftNode.Evaluate(table)/RightNode.Evaluate(table);
        }
    }
}