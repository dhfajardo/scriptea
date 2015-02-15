using scriptea.Lexical;

namespace scriptea.Parsing.Parameters
{
    public class ParameterListp:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.PmComma)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.Id)
                {
                    parser.NextToken();
                    this.Process(parser);
                }
                else
                {
                    throw new ParserException("This was expected a Identifier");
                }
            }
            else
            {
                //Epsilon
            }
        }
    }
}
