using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;
using scriptea.Lexical.States;

namespace scriptea.Lexical
{
    public class Lexer
    {
        public InputStream Input { get; set; }
        public Token GetNextToken()
        {
            var _currentState = new InitialState();
            return _currentState.ProcessState(Input, new Lexeme());
        }
    }
}
