using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class DoWhileNode:StatementNode
    {
        public StatementNode CodeNode { get; set; }
        public ExpressionNode EvaluationNode { get; set; }
    }
}