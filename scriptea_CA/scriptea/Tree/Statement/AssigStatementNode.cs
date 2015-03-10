using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class AssigStatementNode:StatementNode
    {
        public List<ExpressionNode> AssignmentExpressionNode { get; set; }
    }
}