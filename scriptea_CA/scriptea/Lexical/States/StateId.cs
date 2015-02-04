using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public class StateId:IState
    {
        public Token ProcessState(InputStream pInput,Lexeme pLexeme)
        {
            if(char.IsLetter(pInput.CurrentSymbol) || pInput.CurrentSymbol == '_' || char.IsDigit(pInput.CurrentSymbol))
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new StateId().ProcessState(pInput, pLexeme);
            }
            else
            {
                if(!KeyWords.Contains(pLexeme.Value))
                {
                    return new Token { Type = TokenType.Id, LexemeVal = pLexeme.Value, Row = pInput.Row, Column = pInput.Column};
                }
                else
                {
                    return new Token { Type = KeyWords.GetTokenType(pLexeme.Value), LexemeVal = pLexeme.Value, 
                                        Row = pInput.Row, Column = pInput.Column };
                }
            }
        }
    }
}
