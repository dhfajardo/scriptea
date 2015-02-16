using scriptea.Lexical;
using scriptea.Parsing.Expressions.Constructor;

namespace scriptea.Parsing.Statements
{
    public class ThrowStatement:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.KwThrow)
            {
                parser.NextToken();
                new ThrowStatementp().Process(parser);
            }
            else
            {
                //Epsilon
                throw new ParserException("This was expected the token: throw");
            }
        }
    }
}