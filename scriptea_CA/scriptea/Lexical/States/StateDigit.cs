using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public class StateDigit:IState
    {
        public Token ProcessState(InputStream pInput, Lexeme pLexeme)
        {
            if(char.IsDigit(pInput.CurrentSymbol))
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateDigit().ProcessState(pInput, pLexeme);
            }
            else if(pInput.CurrentSymbol == '.')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateFloat1().ProcessState(pInput, pLexeme);
            }
            else
            {
                return new Token { Type = TokenType.LitInteger, LexemeVal = pLexeme.Value, 
                                    Column = pInput.Column, Row = pInput.Row };
            }
        }
    }
}
