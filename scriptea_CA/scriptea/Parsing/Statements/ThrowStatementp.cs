using scriptea.Lexical;
using scriptea.Parsing.Expressions.Constructor;

namespace scriptea.Parsing.Statements
{
    public class ThrowStatementp:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.KwNew)
            {
                parser.NextToken();
                new ConstructorCall().Process(parser);
            }
            else
            {
                //Epsilon
            }
        }
    }
}
