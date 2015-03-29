using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class AssigStatementNode:StatementNode
    {
        public List<ExpressionNode> AssignmentExpressionNode { get; set; }
        public override void Interpret(SymbolTable table, FunctionTable functionTable)
        {
            foreach (var expressionNode in AssignmentExpressionNode)
            {
                expressionNode.Evaluate(table);
            }
        }
    }
}