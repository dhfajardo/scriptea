using scriptea.Tree.Expression;

namespace scriptea.Tree.Others
{
    public class FunctionDeclarationNode:ExpressionNode
    {
        public string ID { get; set; }
        public ExpressionNode ParameterListOptNode { get; set; }
        public ExpressionNode CompoundStatementNode { get; set; }
    }
}