using System.Collections.Generic;

namespace scriptea.Tree.Expression.Operators
{
    public class NewNode
    {
        public string Type { get; set; }
        public List<ExpressionNode> ParametersNodes { get; set; }
    }
}