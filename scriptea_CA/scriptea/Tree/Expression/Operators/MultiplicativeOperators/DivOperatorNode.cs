namespace scriptea.Tree.Expression.Operators.MultiplicativeOperators
{
    public class DivOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate()/RightNode.Evaluate();
        }
    }
}