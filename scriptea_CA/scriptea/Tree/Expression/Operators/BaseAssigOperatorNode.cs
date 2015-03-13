namespace scriptea.Tree.Expression.Operators
{
    public abstract class BaseAssigOperatorNode:ExpressionNode
    {
        public /*IdNode*/ ExpressionNode LeftNode { get; set; }
        public ExpressionNode RightNode { get; set; }

        protected IdNode GetLeftValue()
        {
            if (!(LeftNode is IdNode))
            {
                throw new InterpreterException("Left value is not ID");
            }
            else
            {
                return (IdNode)LeftNode;
            }
        }
    }
}