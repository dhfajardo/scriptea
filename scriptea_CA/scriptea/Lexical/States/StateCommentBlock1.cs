using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public class StateCommentBlock1:IState
    {
        public Token ProcessState(InputStream pInput, Lexeme pLexeme)
        {
            if(pInput.CurrentSymbol == '*')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateCommentBlock2().ProcessState(pInput, pLexeme);
            }
            else if (pInput.CurrentSymbol == (char)0)
            {
                throw new LexerException("Lexical Error: Was expected */', Row: " + pInput.Column + ", Column: " + pInput.CurrentColumn);
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
