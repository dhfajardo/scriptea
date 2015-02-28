using scriptea.Tree.Expression;
using scriptea.Tree.Others;

namespace scriptea.Tree.Statement
{
    public class SwitchNode:StatementNode
    {
        public ExpressionNode EvaluationNode { get; set; }
        public /*BaseCaseNode*/ CaseNode CaseBlockNode { get; set; }
    }
}