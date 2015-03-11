namespace scriptea.Tree.Expression.Operators.MultiplicativeOperators
{
    public class MulOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate()*RightNode.Evaluate();
        }
    }
}