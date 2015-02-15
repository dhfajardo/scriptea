using scriptea.Lexical;

namespace scriptea.Parsing.Statements.Elements
{
    public class IfNot:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.KwElse)
            {
                parser.NextToken();
                new Statementp().Process(parser);
            }
            else
            {
                //Epsilon
            }
        }
    }
}
