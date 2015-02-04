using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public class StateFloat2
    {
        public Token ProcessState(InputStream pInput, Lexeme pLexeme)
        {
            if(char.IsDigit(pInput.CurrentSymbol))
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateFloat2().ProcessState(pInput, pLexeme);
            }
            else
            {
                return new Token { Type = TokenType.LitFloat, LexemeVal = pLexeme.Value, Row = pInput.Row, Column = pInput.Column };
            }
        }
    }
}
