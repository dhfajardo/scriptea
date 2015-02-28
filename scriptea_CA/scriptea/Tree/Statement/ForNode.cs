using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{   
    public class ForNode:StatementNode
    {
        public List<ExpressionNode> StartExpression { get; set; }
        public List<ExpressionNode> EvaluationExpression { get; set; }
        public List<ExpressionNode> EndExpression { get; set; }

    }
}