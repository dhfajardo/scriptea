using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public class StateDiv:IState
    {
        public Token ProcessState(InputStream pInput, Lexeme pLexeme)
        {
            if (pInput.CurrentSymbol == '/')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateCommentLine().ProcessState(pInput, pLexeme);
            }
            else if (pInput.CurrentSymbol == '*')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateCommentBlock1().ProcessState(pInput, pLexeme);
            }
            else if (pInput.CurrentSymbol == '=')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new Token { Type = TokenType.OpAssigDiv, LexemeVal = pLexeme.Value, Row = pInput.Row, Column = pInput.Column };
            }
            else
            {
                return new Token { Type = TokenType.OpDiv, LexemeVal = pLexeme.Value, Row = pInput.Row, Column = pInput.Column };
            }
        }
    }
}
