using System;

namespace scriptea.Tree.Expression.Operators.RelationalOperators
{
    public class EquivOperatorNode:BinaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            return LeftNode.Evaluate(table) == RightNode.Evaluate(table);
        }
    }
}