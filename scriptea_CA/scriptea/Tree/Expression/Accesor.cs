using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace scriptea.Tree.Expression
{
    public abstract class Accesor
    {
        public Accesor NextAccesor { get; set; }
        public abstract dynamic Evaluate(dynamic value, SymbolTable table);
        public abstract void SetValue(object value, SymbolTable table);
    }

    public class FunctionAccesor : Accesor
    {
        public string Name { get; set; }
        public List<ExpressionNode> ParameterList { get; set; }
        public override dynamic Evaluate(dynamic value, SymbolTable table)
        {
            List<object> evalParameters = new List<object>();
            foreach (var expressionNode in ParameterList)
            {
                evalParameters.Add(expressionNode.Evaluate(table));
            }
            Type type = value.GetType();
            MethodInfo[] methodInfos = type.GetMethods();
            MethodInfo functionCall = null;
            foreach (var methodInfo in methodInfos)
            {
                if (FunctionMatch(methodInfo, Name, evalParameters))
                {
                    functionCall = methodInfo;
                    break;
                }
            }
            if (functionCall != null)
            {
                var _result = functionCall.Invoke(value, evalParameters.ToArray());/*null static*/
                if (NextAccesor != null)
                {
                    return NextAccesor.Evaluate(_result, table);
                }
                else
                {
                    return _result;
                }
            }
            else
            {
                throw new Exception("Function: " + Name + " Not exists");
            }
        }

        private bool FunctionMatch(MethodInfo methodInfo, string name, List<object> evalParameters)
        {
            if (methodInfo.Name != name)
            {
                return false;
            }
            var parameter = methodInfo.GetParameters();
            if (parameter.Count() != evalParameters.Count)
            {
                return false;
            }
            for (int i = 0; i < parameter.Count(); i++)
            {
                if (!(parameter[i].ParameterType.IsAssignableFrom(evalParameters[i].GetType())))
                {
                    return false;
                }
            }
            return true;
        }

        public override void SetValue(object value, SymbolTable table)
        {
            throw new NotImplementedException();
        }
    }

    public class FieldAccesor : Accesor
    {
        public string Name { get; set; }
        public override dynamic Evaluate(dynamic value, SymbolTable table)
        {
            Type type = value.GetType();
            var field = type.GetField(Name, BindingFlags.Public | BindingFlags.Instance |
                                            BindingFlags.Static | BindingFlags.NonPublic);
            if (field != null)
            {
                var fieldvalue = field.GetValue(value);
                if (NextAccesor != null)
                {
                    return NextAccesor.Evaluate(fieldvalue, table);
                }
                else
                {
                    return fieldvalue;
                }
            }
            else
            {
                var property = type.GetProperty(Name, BindingFlags.Public | BindingFlags.Instance |
                                           BindingFlags.Static | BindingFlags.NonPublic);
                if (property != null)
                {
                    var fieldvalue = property.GetValue(value, null);
                    if (NextAccesor != null)
                    {
                        return NextAccesor.Evaluate(fieldvalue, table);
                    }
                    else
                    {
                        return fieldvalue;
                    } 
                }
                else
                {
                    throw new Exception(Name + " Not exits");
                }
            }
        }

        public override void SetValue(object value, SymbolTable table)
        {
            Type type = value.GetType();
            var field = type.GetField(Name, BindingFlags.Public | BindingFlags.Instance |
                                            BindingFlags.Static | BindingFlags.NonPublic);
            if (field != null)
            {
                var fieldvalue = field.GetValue(value);
                if (NextAccesor != null)
                {
                     NextAccesor.SetValue(fieldvalue, table);
                }
                else
                {
                    table.AddSymbol(Name, fieldvalue);
                }
            }
            else
            {
                var property = type.GetProperty(Name, BindingFlags.Public | BindingFlags.Instance |
                                           BindingFlags.Static | BindingFlags.NonPublic);
                if (property != null)
                {
                    var fieldvalue = property.GetValue(value, null);
                    if (NextAccesor != null)
                    {
                        NextAccesor.SetValue(fieldvalue, table);
                    }
                    else
                    {
                        table.AddSymbol(Name,fieldvalue);
                    }
                }
                else
                {
                    throw new Exception(Name + " Not exits");
                }
            }
        }
    }

    public class IndexAcessor : Accesor
    {
        public ExpressionNode IndexList { get; set; }
        public override dynamic Evaluate(dynamic value, SymbolTable table)
        {
            var _index = IndexList.Evaluate(table);
            var indexValue = value[_index];
            if (NextAccesor != null)
            {
                return NextAccesor.Evaluate(indexValue, table);
            }
            else
            {
                return indexValue;
            }
        }

        public override void SetValue(object value, SymbolTable table)
        {
            throw new NotImplementedException();
        }
    }
}