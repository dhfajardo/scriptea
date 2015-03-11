namespace scriptea.Tree.Expression.Operators
{
    public class BitwiseXOrNode:BinaryOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate() ^ RightNode.Evaluate();
        }
    }
}