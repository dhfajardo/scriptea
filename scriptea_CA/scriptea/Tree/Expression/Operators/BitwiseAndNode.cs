namespace scriptea.Tree.Expression.Operators
{
    public class BitwiseAndNode:BinaryOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate() & RightNode.Evaluate();
        }
    }
}