using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class DoWhileNode:StatementNode
    {
        public List<StatementNode> CodeNode { get; set; }
        public ExpressionNode EvaluationNode { get; set; }
        public override void Interpret(SymbolTable table)
        {
            do
            {
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
            } while (EvaluationNode.Evaluate(table));
        }
    }
}