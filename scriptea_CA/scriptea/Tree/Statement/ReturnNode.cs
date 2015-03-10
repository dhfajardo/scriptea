using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class ReturnNode:StatementNode
    {
        public List<ExpressionNode> ReturnExpressionNode { get; set; }
    }
}