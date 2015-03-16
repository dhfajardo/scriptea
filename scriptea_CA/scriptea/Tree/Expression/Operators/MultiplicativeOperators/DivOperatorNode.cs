namespace scriptea.Tree.Expression.Operators.MultiplicativeOperators
{
    public class DivOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {

            return LeftNode.Evaluate(table)%2 != 0 || RightNode.Evaluate(table)%2 != 0
                ? ((float) LeftNode.Evaluate(table)/(float) RightNode.Evaluate(table))
                : LeftNode.Evaluate(table)/RightNode.Evaluate(table);
        }
    }
}