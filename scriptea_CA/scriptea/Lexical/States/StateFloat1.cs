using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public class StateFloat1
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
                throw new LexerException("Symbol: "+ pInput.CurrentSymbol +" is not a number, a number was expected, Row: " + pInput.Row + ", Column: " + pInput.CurrentColumn);
            }
        }
    }
}
