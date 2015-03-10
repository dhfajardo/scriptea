using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class DoWhileNode:StatementNode
    {
        public List<StatementNode> CodeNode { get; set; }
        public ExpressionNode EvaluationNode { get; set; }
    }
}