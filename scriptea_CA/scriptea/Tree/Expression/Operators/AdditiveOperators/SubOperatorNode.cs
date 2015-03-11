namespace scriptea.Tree.Expression.Operators.AdditiveOperators
{
    public class SubOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate() - RightNode.Evaluate();
        }
    }
}