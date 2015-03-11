namespace scriptea.Tree.Expression.Operators.MultiplicativeOperators
{
    public class ModOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate()%RightNode.Evaluate();
        }
    }
}