using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Tree.Expression.Operators
{
    public class OrNode:BinaryOperatorNode
    {
        public override dynamic Evaluate()
        {
            return LeftNode.Evaluate() || RightNode.Evaluate();
        }
    }
}
