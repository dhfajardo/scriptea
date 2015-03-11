namespace scriptea.Tree.Expression.Literals
{
    public class NullNode:ExpressionNode
    {
        public override dynamic Evaluate()
        {
            return null;
        }
    }
}