using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Tree.Expression
{
    public class IdNode:ExpressionNode
    {
        public string Name { get; set; }
        public Accesor Accesor { get; set; }
        public override dynamic Evaluate(SymbolTable table)
        {
            var value = table.GetSymbol(Name);
            if (Accesor != null)
            {
                return Accesor.Evaluate(value, table);
            }
            else
            {
                return value;
            }
        }

        public void SetValue(dynamic value, SymbolTable table)
        {
            if (Accesor == null)
            {
                table.AddSymbol(Name, value);
            }
            else
            {
                Accesor.SetValue(value, table);
            }
        }
    }
}
