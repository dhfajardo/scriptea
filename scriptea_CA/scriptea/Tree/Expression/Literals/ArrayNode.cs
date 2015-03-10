using System.Collections.Generic;

namespace scriptea.Tree.Expression.Literals
{
    public class ArrayNode:ExpressionNode
    {
        public List<ExpressionNode> ElementsArray { get; set; }
    }
}