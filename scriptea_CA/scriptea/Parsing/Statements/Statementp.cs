using scriptea.Lexical;

namespace scriptea.Parsing.Statements
{
    public class Statementp:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.PmLeftCurlyBracket)
            {
                new CompoundStatement().Process(parser);
            }
            else
            {
                new Statement().Process(parser);
            }
        }
    }
}
