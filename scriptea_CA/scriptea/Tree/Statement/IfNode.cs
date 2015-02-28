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
        public ExpressionNode EvaluationNode { get; set; }
        public StatementNode IfCode { get; set; }
        public ElseNode IfNotCode { get; set; }
    }
}
