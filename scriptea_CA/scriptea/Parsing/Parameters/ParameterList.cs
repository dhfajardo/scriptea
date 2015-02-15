using scriptea.Lexical;

namespace scriptea.Parsing.Parameters
{
    public class ParameterList:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                parser.NextToken();
                new ParameterListp().Process(parser);
            }
            else
            {
                throw new ParserException("This was expected a Identifier");
            }
        }
    }
}