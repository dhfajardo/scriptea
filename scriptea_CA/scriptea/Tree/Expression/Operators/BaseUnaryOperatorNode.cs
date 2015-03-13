namespace scriptea.Tree.Expression.Operators
{
    public abstract class BaseUnaryOperatorNode:ExpressionNode
    {
        public ExpressionNode ValueNode { get; set; }
        protected IdNode GetValue()
        {
            if (!(ValueNode is IdNode))
            {
                throw new InterpreterException("Left value is not ID");
            }
            else
            {
                return (IdNode)ValueNode;
            }
        }
    }
}