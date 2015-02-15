using scriptea.Lexical;

namespace scriptea.Parsing.Operators
{
    public class IncrementOperator:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.OpInc)
            {
                parser.NextToken();
            }
            else
            {
                throw new LexerException("This was expected ++");
            }

        }
    }
}