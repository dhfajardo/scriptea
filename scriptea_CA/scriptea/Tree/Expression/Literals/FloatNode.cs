namespace scriptea.Tree.Expression.Literals
{
    public class FloatNode:ExpressionNode
    {
        public float Value { get; set; }
        public override dynamic Evaluate()
        {
            return Value;
        }
    }
}