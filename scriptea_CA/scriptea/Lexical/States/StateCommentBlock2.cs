using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public class StateCommentBlock2:IState
    {
        public Token ProcessState(InputStream pInput, Lexeme pLexeme)
        {
            if(pInput.CurrentSymbol == '/' || pInput.CurrentSymbol == '\r')
            {
                //pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                //return new Token { Type = TokenType.COMMENT_BLOCK, LexemeVal = pLexeme.Value, Row = pInput.Row, Column = pInput.Column };
                return new InitialState().ProcessState(pInput, pLexeme= new Lexeme());
            }
            else
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateCommentBlock1().ProcessState(pInput, pLexeme);
            }
        }
    }
}
