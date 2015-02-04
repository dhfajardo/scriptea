using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public class StateAnd:IState
    {
        public Token ProcessState(InputStream pInput, Lexeme pLexeme)
        {
            if(pInput.CurrentSymbol =='&')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new Token { Type = TokenType.OpAnd, LexemeVal = pLexeme.Value, Row = pInput.Row, Column = pInput.Column };
            }
            else
            {
                throw new LexerException("Symbol: " + pInput.CurrentSymbol + " not recognized");
            }
        }
    }
}
