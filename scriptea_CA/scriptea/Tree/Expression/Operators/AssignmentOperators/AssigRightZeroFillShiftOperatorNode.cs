namespace scriptea.Tree.Expression.Operators.AssignmentOperators
{
    public class AssigRightZeroFillShiftOperatorNode:BaseAssigOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            var _value = (int)((uint)LeftNode.Evaluate(table) >> RightNode.Evaluate(table));
            var _leftId = GetLeftValue();
            table.AddSymbol(_leftId.Name,_value);
            return _value;
        }
    }
}