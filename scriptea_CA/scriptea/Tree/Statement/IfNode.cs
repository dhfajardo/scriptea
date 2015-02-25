using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Parsing.Expressions;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class IfNode:StatementNode
    {
        public ExpressionNode AssignmentExpressionNode { get; set; }
        public ExpressionNode StatementNode { get; set; }
        public ExpressionNode IfNotNode { get; set; }
    }
}
