using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public class StateCommentLine:IState
    {
        public Token ProcessState(InputStream pInput, Lexeme pLexeme)
        {
            if(pInput.CurrentSymbol == '\n' || pInput.CurrentSymbol == '\r')
            {
                //pLexeme.addSymbol(pInput.CurrentSymbol);
                //pInput.ConsumeSymbol();
                //return new Token { Type = TokenType.COMMENT_LINE, LexemeVal = pLexeme.Value, Row = pInput.Row, Column = pInput.Column };
                return new InitialState().ProcessState(pInput, pLexeme = new Lexeme());
            }
            else
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateCommentLine().ProcessState(pInput, pLexeme);
            }
        }
    }
}
