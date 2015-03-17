using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{   
    public class ForNode:StatementNode
    {
        public List<ExpressionNode> StartExpressionNodes { get; set; }
        public List<ExpressionNode> EvaluationNodes { get; set; }
        public List<ExpressionNode> EndExpressionNodes { get; set; }

        public List<StatementNode> CodeNode { get; set; }

        public override void Interpret(SymbolTable table)
        {
            foreach (var startExpressionNode in StartExpressionNodes)
            {
                startExpressionNode.Evaluate(table);
            }
            while (true)
            {
                foreach (var evaluationNode in EvaluationNodes)
                {
                    if (!evaluationNode.Evaluate(table))
                    {
                        return;
                    }
                }
                try
                {
                    foreach (var statementNode in CodeNode)
                    {
                        statementNode.Interpret(table);
                    }
                }
                catch (BreakException)
                {
                    return;
                }
                catch (ContinueException)
                {
                    
                }
                foreach (var endExpressionNode in EndExpressionNodes)
                {
                    endExpressionNode.Evaluate(table);
                }
            }
        }
    }
}