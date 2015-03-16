using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public class StateBitwiseXOr:IState
    {
        public Token ProcessState(InputStream pInput, Lexeme pLexeme)
        {
            if(pInput.CurrentSymbol =='=')
            {
                pLexeme.addSymbol(pInput.CurrentSymbol);
                pInput.ConsumeSymbol();
                return new Token
                {
                    Type = TokenType.OpAssigBitwiseXOr,
                    LexemeVal = pLexeme.Value,
                    Row = pInput.Row,
                    Column = pInput.Column
                };
            }
            else
            {
                return new Token
                {
                    Type = TokenType.OpBitwiseXOr,
                    LexemeVal = pLexeme.Value,
                    Row = pInput.Row,
                    Column = pInput.Column
                };
            }
        }
    }
}