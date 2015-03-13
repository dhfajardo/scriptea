using System;
using System.Collections.Generic;

namespace scriptea.Tree.Expression.Literals
{
    public class ArrayNode:ExpressionNode
    {
        public List<ExpressionNode> ElementsArray { get; set; }
        public override dynamic Evaluate(SymbolTable table)
        {
            List<Object> _result = new List<object>();
            foreach (var element in ElementsArray)
            {
                _result.Add(element.Evaluate(table));
            }
            return _result.ToArray();
        }
    }
}