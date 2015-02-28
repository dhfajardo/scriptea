using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{   
    public class ForNode:StatementNode
    {
        public List<ExpressionNode> StartExpressionNodes { get; set; }
        public List<ExpressionNode> EvaluationExpressionNodes { get; set; }
        public List<ExpressionNode> EndExpressionNodes { get; set; }

        public StatementNode CodeNode { get; set; }

    }
}