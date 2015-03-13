namespace scriptea.Tree.Expression.Operators.AssignmentOperators
{
    public class AssigDivOperatorNode:BaseAssigOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            var _value = LeftNode.Evaluate(table)/RightNode.Evaluate(table);
            var _leftId = GetLeftValue();
            table.AddSymbol(_leftId.Name,_value);
            return _value;
        }
    }
}