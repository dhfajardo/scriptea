using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public class StateSum:IState
    {
        public Token ProcessState(InputStream pInput, Lexeme pLexeme)
        {
            if(pInput.CurrentSymbol == '+')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new Token { Type = TokenType.OpInc, LexemeVal = pLexeme.Value, Column = pInput.Column, Row = pInput.Row };
            }
            else if(pInput.CurrentSymbol == '=')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new Token { Type = TokenType.OpAssigSum, LexemeVal = pLexeme.Value, Column = pInput.Column, Row = pInput.Row };
            }
            else
            {
                return new Token { Type = TokenType.OpSum, LexemeVal = pLexeme.Value, Column = pInput.Column, Row = pInput.Row };
            }
        }
    }
}
