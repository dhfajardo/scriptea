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
        public StatementNode IfCode { get; set; }
        public StatementNode IfNotCode { get; set; }
    }
}
