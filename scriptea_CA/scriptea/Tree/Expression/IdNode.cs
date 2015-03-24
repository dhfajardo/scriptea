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

        public void SetValue(dynamic value, SymbolTable table)
        {
            if (Accesor == null && !(this.GetType() is IndexAcessor))
            {
                table.AddSymbol(Name, value);
            }
            else
            {
                SearchAccesorToSet(Accesor, Name,value,table);
                Accesor.SetValue(value, table, Name);
            }
        }

        public Accesor SearchAccesor(Accesor _accesor,string value)
        {
            if (_accesor!=null)
            {

                if (_accesor is FunctionAccesor)
                {
                    //value += "." + ((FunctionAccesor)_accesor).Name;
                    Name = value;
                    ((FunctionAccesor) _accesor).IsStatic = true;
                    return _accesor;
                }
                else if (_accesor is FieldAccesor)
                {
                    if (_accesor.NextAccesor == null)
                    {
                        Name = value;
                        ((FieldAccesor) _accesor).IsStatic = true;
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

        public void SearchAccesorToSet(Accesor _accesor, dynamic value, dynamic valueToAssig, SymbolTable table)
        {
            if (_accesor != null)
            {

                if (_accesor is FunctionAccesor)
                {
                    throw new Exception("The functions are not assigned");
                }
                else if (_accesor is FieldAccesor)
                {
                    if (_accesor.NextAccesor == null)
                    {
                        ((FieldAccesor)_accesor).SetValue(value,table,valueToAssig);
                    }
                    value += "." + ((FieldAccesor)_accesor).Name;
                    SearchAccesorToSet(_accesor.NextAccesor,value,valueToAssig,table);
                }
                else if (_accesor is IndexAcessor)
                {
                    if (_accesor.NextAccesor == null)
                    {
                        ((IndexAcessor) _accesor).SetValue(value, table, valueToAssig);
                    }
                    SearchAccesorToSet(_accesor.NextAccesor, value, valueToAssig, table);
                }
            }
        }
    }
}
