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
        public List<StatementNode> CodeNode { get; set; }
        public override void Interpret(SymbolTable table, FunctionTable functionTable)
        {
            while (EvaluationNode.Evaluate(table))
            {
                try
                {
                    foreach (var statementNode in CodeNode)
                    {
                        statementNode.Interpret(table, functionTable);
                    }
                }
                catch (BreakException)
                {
                    return;
                }
                catch (ContinueException)
                {
                    
                }
            }
        }
    }
}
