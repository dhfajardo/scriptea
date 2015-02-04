using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Lexical.Input
{
    public class Lexeme
    {
        private string _lexeme = "";
        public void addSymbol(char pSymbol)
        {
            _lexeme += pSymbol;
        }
        public string Value { get { return _lexeme; } }
    }
}
