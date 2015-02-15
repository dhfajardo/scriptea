using scriptea.Lexical;

namespace scriptea.Parsing.Operators
{
    public class AdditiveOperator:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.OpSum)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpSub)
            {
                parser.NextToken();
            }
            else
            {
                throw  new ParserException("This was expected + or -");
            }
        }
    }
}