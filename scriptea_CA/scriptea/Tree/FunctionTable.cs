using System.Collections.Generic;

namespace scriptea.Tree
{
    public class FunctionTable
    {
        SortedDictionary<string,dynamic> _symbolTable =new SortedDictionary<string, dynamic>();

        public void AddSymbol(string name, dynamic value)
        {
            if (this._symbolTable.ContainsKey(name))
            {
                this._symbolTable[name] = value;
            }
            else
            {
                this._symbolTable.Add(name, value);
            }
        }

        public dynamic GetSymbol(string name)
        {
            if (this._symbolTable.ContainsKey(name))
            {
                return this._symbolTable[name];
            }
            else
            {
                return null;
            }
        }

        public void DeleteSymbol(string name)
        {
            this._symbolTable.Remove(name);
        }
    }
}