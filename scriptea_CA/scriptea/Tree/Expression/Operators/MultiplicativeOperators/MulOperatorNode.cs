namespace scriptea.Tree.Expression.Operators.MultiplicativeOperators
{
    public class MulOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            return LeftNode.Evaluate(table)*RightNode.Evaluate(table);
        }
    }
}