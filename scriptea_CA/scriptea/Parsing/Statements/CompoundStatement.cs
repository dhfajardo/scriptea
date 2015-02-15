using scriptea.Lexical;

namespace scriptea.Parsing.Statements
{
    public class CompoundStatement:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.PmLeftCurlyBracket)
            {
                parser.NextToken();
                new StatementList().Process(parser);
                if (parser.CurrenToken.Type == TokenType.PmRightCurlyBracket)
                {
                    parser.NextToken();
                }
                else
                {
                    throw new ParserException("This was expected }");
                }
            }
            else
            {
                throw new ParserException("This was expected {");
            }
        }
    }
}