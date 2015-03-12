using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace scriptea.Tree
{
    public class SymbolTable
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
            return this._symbolTable[name];
        }

        public void DeleteSymbol(string name)
        {
            this._symbolTable.Remove(name);
        }
    }
}
