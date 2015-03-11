using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Tree.Expression.Operators.AssignmentOperators
{
    public class AssigOperatorNode:BaseAssigOperatorNode
    {
        public override dynamic Evaluate()
        {
            return RightNode.Evaluate();
        }
    }
}
