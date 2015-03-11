using System;
using System.Collections.Generic;
using scriptea.Tree.Statement;

namespace scriptea.Tree.Expression.Operators
{
    public class NewNode:ExpressionNode
    {
        public string TypeName { get; set; }
        public List<ExpressionNode> Parameters { get; set; }

        public override dynamic Evaluate()
        {
            List<Object> _parameterValue = new List<object>();
            foreach (var parametersNode in Parameters)
            {
                _parameterValue.Add(parametersNode.Evaluate());
            }
           return Activator.CreateInstance(Type.GetType(TypeName),_parameterValue.ToArray());
        }
    }
}