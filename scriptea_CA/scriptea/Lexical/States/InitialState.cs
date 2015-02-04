using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public class InitialState:IState
    {
        public Token    ProcessState(InputStream pInput, Lexeme pLexeme)
        {
            pInput.CtrlNewToken = true;
            if(char.IsLetter(pInput.CurrentSymbol) || pInput.CurrentSymbol == '_')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateId().ProcessState(pInput, pLexeme);
            }
            else if(PunctuationMarks.Contains(pInput.CurrentSymbol))
            {
                var _token = PunctuationMarks.GetTokenType(pInput.CurrentSymbol);
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new Token { Type = _token, LexemeVal = pLexeme.Value, Row = pInput.Row, Column = pInput.Column };
            }
            else if(char.IsDigit(pInput.CurrentSymbol))
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateDigit().ProcessState(pInput, pLexeme);
            }
            else if(pInput.CurrentSymbol == '=')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateAssig().ProcessState(pInput, pLexeme);
            }
            else if(pInput.CurrentSymbol == '+')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateSum().ProcessState(pInput, pLexeme);
            }
            else if (pInput.CurrentSymbol == '-')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateSub().ProcessState(pInput, pLexeme);
            }
            else if (pInput.CurrentSymbol == '*')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateMul().ProcessState(pInput, pLexeme);
            }
            else if (pInput.CurrentSymbol == '%')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateMod().ProcessState(pInput, pLexeme);
            }
            else if (pInput.CurrentSymbol == '!')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateNot().ProcessState(pInput, pLexeme);
            }
            else if (pInput.CurrentSymbol == '<')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateLessThan().ProcessState(pInput, pLexeme);
            }
            else if (pInput.CurrentSymbol == '>')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateGreaterThan().ProcessState(pInput, pLexeme);
            }
            else if (pInput.CurrentSymbol == '&')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateAnd().ProcessState(pInput, pLexeme);
            }
            else if (pInput.CurrentSymbol == '|')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateOr().ProcessState(pInput, pLexeme);
            }
            else if (pInput.CurrentSymbol == '/')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateDiv().ProcessState(pInput, pLexeme);
            }
            else if (pInput.CurrentSymbol == '\'')
            {
                //pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateString1().ProcessState(pInput, pLexeme);
            }
            else if (pInput.CurrentSymbol == '\"')
            {
                //pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateString2().ProcessState(pInput, pLexeme);
            }
            else if (char.IsWhiteSpace(pInput.CurrentSymbol) || pInput.CurrentSymbol == '\n'
                    || pInput.CurrentSymbol == '\r' || pInput.CurrentSymbol == '\t')
            {
                pInput.ConsumeSymbol();
                return new InitialState().ProcessState(pInput, pLexeme);
            }
            else if (pInput.CurrentSymbol == (char)0)
            {
                return new Token { Type = TokenType.Eof, LexemeVal = "", Row = pInput.Row, Column = pInput.Column };
            }
            else
            {
                throw new LexerException("Symbol: " + pInput.CurrentSymbol + " not recognized");
            }
        }
    }
}
