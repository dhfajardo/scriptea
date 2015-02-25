namespace scriptea.Tree.Expression
{
    public class FunctionNode:ExpressionNode
    {
        public string Name { get; set; }
        public Accesor Accesor { get; set; }
        public ExpressionNode ParameterList { get; set; }
    }
}