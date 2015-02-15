using scriptea.Lexical;

namespace scriptea.Parsing.Statements.Blocks
{
    public class FinallyBlock:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.KwFinally)
            {
                parser.NextToken();
                new CompoundStatement().Process(parser);
            }
            else
            {
                //Epsilon
            }
        }
    }
}