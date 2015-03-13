namespace scriptea.Tree.Expression.Operators.UnaryOperators
{
    public class IncPosOperatorNode:BaseUnaryOperatorNode
    {
        public override dynamic Evaluate(SymbolTable table)
        {
            var _id = GetValue();
            var _value = _id.Evaluate(table);
            table.AddSymbol(_id.Name, _value + 1);
            return _value;
        }
    }
}