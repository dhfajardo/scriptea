﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public class StateLessThan:IState
    {
        public Token ProcessState(InputStream pInput, Lexeme pLexeme)
        {
            if(pInput.CurrentSymbol == '=')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new Token { Type = TokenType.OpLessEqualThan, LexemeVal = pLexeme.Value, Row = pInput.Row, Column = pInput.Column };
            }
            else if (pInput.CurrentSymbol == '<')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateLeftShift().ProcessState(pInput,pLexeme);
            }
            else
            {
                return new Token { Type = TokenType.OpLessThan, LexemeVal = pLexeme.Value, Row = pInput.Row, Column = pInput.Column };
            }
        }
    }
}
