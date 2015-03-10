using System.Collections.Generic;
using scriptea.Tree.Expression;
using scriptea.Tree.Statement;

namespace scriptea.Tree.Others
{
    public class CaseNode:BaseCaseNode
    {
        public ExpressionNode EvaluationNode { get; set; }
    }
}