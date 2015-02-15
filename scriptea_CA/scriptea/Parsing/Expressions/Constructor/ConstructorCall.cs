using scriptea.Lexical;

namespace scriptea.Parsing.Expressions.Constructor
{
    public class ConstructorCall:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                parser.NextToken();
                new ConstructorCallp().Process(parser);
            }
            else
            {
                throw new ParserException("This was expected Identifier");
            }
        }
    }
}