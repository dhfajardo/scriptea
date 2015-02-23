using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Literals
{
    public class IntegerNode:ExpressionNode
    {
        public int Value { get; set; }
    }
}
