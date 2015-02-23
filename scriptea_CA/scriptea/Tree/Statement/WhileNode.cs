using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class WhileNode:ExpressionNode
    {
        public ExpressionNode AssignmentExpressionNode { get; set; }
        public ExpressionNode StatementNode { get; set; }
    }
}
