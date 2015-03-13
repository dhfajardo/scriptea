﻿namespace scriptea.Tree.Expression.Literals
{
    public class BooleanNode:ExpressionNode
    {
        public bool Value { get; set; }
        public override dynamic Evaluate(SymbolTable table)
        {
            return Value;
        }
    }
}