using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public class StateAssig:IState
    {
        public Token ProcessState(InputStream pInput, Lexeme pLexeme)
        {
            if(pInput.CurrentSymbol == '=')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateEquiv().ProcessState(pInput, pLexeme);
            }
            else
            {
                return new Token { Type = TokenType.OpAssig, LexemeVal = pLexeme.Value, Column = pInput.Column, Row = pInput.Row };
            }
        }
    }
}
