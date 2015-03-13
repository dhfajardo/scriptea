using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Tree.Expression.Operators.AssignmentOperators
{
    public class AssigOperatorNode:BaseAssigOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            var _value = RightNode.Evaluate(table);
            var _idLeft = GetLeftValue();
            table.AddSymbol(_idLeft.Name,_value);
            return _value;
        }
    }
}
