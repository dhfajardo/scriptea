using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Tree.Expression.Operators
{
    public abstract class BinaryOperatorNode:ExpressionNode
    {
        public ExpressionNode LeftNode { get; set; }
        public ExpressionNode RightNode { get; set; }

    }
}
