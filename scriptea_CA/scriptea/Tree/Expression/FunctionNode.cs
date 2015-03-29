using System.Collections.Generic;
using scriptea.Tree.Statement;

namespace scriptea.Tree.Expression
{
    public class FunctionNode:ExpressionNode
    {
        public string Name { get; set; }
        //public IdNode Id { get; set;}
        public Accesor Accesor { get; set; }
        //public List<IdNode> ParameterList { get; set; }
        //public List<StatementNode> Statements { get; set; }
        public override dynamic Evaluate(SymbolTable table)
        {
            var value = table.GetSymbol(Name);
            if (Accesor != null)
            {
                Accesor _accesor = SearchAccesor(Accesor, Name);
                if (_accesor != null)
                {
                    Accesor = _accesor;
                    return Accesor.Evaluate(Name, table);
                }
                return Accesor.Evaluate(value, table);
            }
            else
            {
                return value;
            }
        }

        public Accesor SearchAccesor(Accesor _accesor, string value)
        {
            if (_accesor != null)
            {

                if (_accesor is FunctionAccesor)
                {
                    //value += "." + ((FunctionAccesor)_accesor).Name;
                    Name = value;
                    ((FunctionAccesor)_accesor).IsStatic = true;
                    return _accesor;
                }
                else if (_accesor is FieldAccesor)
                {
                    if (_accesor.NextAccesor == null)
                    {
                        Name = value;
                        ((FieldAccesor)_accesor).IsStatic = true;
                        return _accesor;
                    }
                    value += "." + ((FieldAccesor)_accesor).Name;
                    return SearchAccesor(_accesor.NextAccesor, value);
                }
                else if (_accesor is IndexAcessor)
                {
                    return null;
                }
            }
            return null;
        }
    }
}