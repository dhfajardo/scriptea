using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public class StateString2:IState
    {
        public Token ProcessState(InputStream pInput, Lexeme pLexeme)
        {
            if (pInput.CurrentSymbol == '\\')
            {
                //pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                if (pInput.CurrentSymbol == '\'')
                {
                    pLexeme.addSymbol('\'');
                    pInput.ConsumeSymbol();
                    return new StateString2().ProcessState(pInput, pLexeme);
                }
                else if (pInput.CurrentSymbol == '\"')
                {
                    pLexeme.addSymbol('\"');
                    pInput.ConsumeSymbol();
                    return new StateString2().ProcessState(pInput, pLexeme);
                }
                else if (pInput.CurrentSymbol == '\\')
                {
                    pLexeme.addSymbol('\\');
                    pInput.ConsumeSymbol();
                    return new StateString2().ProcessState(pInput, pLexeme);
                }
                else if (pInput.CurrentSymbol == 'n')
                {
                    pLexeme.addSymbol('\n');
                    pInput.ConsumeSymbol();
                    return new StateString2().ProcessState(pInput, pLexeme);
                }
                else if (pInput.CurrentSymbol == 'r')
                {
                    pLexeme.addSymbol('\r');
                    pInput.ConsumeSymbol();
                    return new StateString2().ProcessState(pInput, pLexeme);
                }
                else if (pInput.CurrentSymbol == 't')
                {
                    pLexeme.addSymbol('\t');
                    pInput.ConsumeSymbol();
                    return new StateString2().ProcessState(pInput, pLexeme);
                }
                else if (pInput.CurrentSymbol == 'b')
                {
                    pLexeme.addSymbol('\b');
                    pInput.ConsumeSymbol();
                    return new StateString2().ProcessState(pInput, pLexeme);
                }
                else if (pInput.CurrentSymbol == 'f')
                {
                    pLexeme.addSymbol('\f');
                    pInput.ConsumeSymbol();
                    return new StateString2().ProcessState(pInput, pLexeme);
                }
                else
                {
                    throw new LexerException("Symbol: " + pInput.CurrentSymbol + " not recognized");
                }
            }
            if (pInput.CurrentSymbol == '\"')
            {
                //pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new Token { Type = TokenType.LitString, LexemeVal = pLexeme.Value, Row = pInput.Row, Column = pInput.Column };
            }
            else
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateString2().ProcessState(pInput, pLexeme);
            }
        }
    }
}
