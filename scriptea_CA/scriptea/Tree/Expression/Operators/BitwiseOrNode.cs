namespace scriptea.Tree.Expression.Operators
{
    public class BitwiseOrNode:BinaryOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate() | RightNode.Evaluate();
        }
    }
}