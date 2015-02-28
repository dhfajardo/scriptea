using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class WhileNode:StatementNode
    {
        public ExpressionNode EvaluationNode { get; set; }
        public StatementNode CodeNode { get; set; }
    }
}
