using System.Collections.Generic;
using scriptea.Tree.Expression;
using scriptea.Tree.Statement;

namespace scriptea.Tree.Others
{
    public class FunctionDeclarationNode:ExpressionNode
    {
        public string ID { get; set; }
        public List<ExpressionNode> ParametersNodes { get; set; }
        public StatementNode CodeNode { get; set; }
    }
}