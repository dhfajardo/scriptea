using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public class StateLeftShift:IState
    {
        public Token ProcessState(InputStream pInput, Lexeme pLexeme)
        {
            if(pInput.CurrentSymbol == '=')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new Token
                {
                    Type = TokenType.OpAssigLeftShift,
                    LexemeVal = pLexeme.Value,
                    Row = pInput.Row,
                    Column = pInput.Column
                };
            }
            else 
            {
                return new Token
                {
                    Type = TokenType.OpLeftShift,
                    LexemeVal = pLexeme.Value,
                    Row = pInput.Row,
                    Column = pInput.Column
                };
            }
        }
    }
}