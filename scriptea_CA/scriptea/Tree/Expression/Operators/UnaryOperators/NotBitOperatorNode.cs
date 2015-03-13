using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Tree.Expression.Operators.UnaryOperators
{
    public class NotBitOperatorNode:BaseUnaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            return ~ValueNode.Evaluate(table);
        }
    }
}
