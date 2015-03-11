namespace scriptea.Tree.Expression.Operators.UnaryOperators
{
    public class NegativeOperatorNode:BaseUnaryOperatorNode
    {
        public override dynamic Evaluate()
        {
            return ValueNode.Evaluate()*-1;
        }
    }
}