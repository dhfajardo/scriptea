namespace scriptea.Tree.Expression.Operators.AdditiveOperators
{
    public class SumOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate() + RightNode.Evaluate();
        }
    }
}