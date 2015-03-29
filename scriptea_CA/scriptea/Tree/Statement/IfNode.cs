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
        public List<StatementNode> IfCode { get; set; }
        public ElseNode IfNotCode { get; set; }
        public override void Interpret(SymbolTable table, FunctionTable functionTable)
        {
            if (EvaluationNode.Evaluate(table))
            {
                foreach (var statementNode in IfCode)
                {
                    statementNode.Interpret(table, functionTable);
                }
            }
            else
            {
                IfNotCode.Interpret(table, functionTable);
            }
        }
    }
}
