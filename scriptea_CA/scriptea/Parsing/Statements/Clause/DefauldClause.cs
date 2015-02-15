using scriptea.Lexical;

namespace scriptea.Parsing.Statements.Clause
{
    public class DefauldClause:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.KwDefault)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.PmDot)
                {
                    parser.NextToken();
                    new Statementp().Process(parser);
                    new CaseClauseList().Process(parser);
                }
                else
                {
                    throw new ParserException("This was expected :");
                }
            }
            else
            {
                //Epsilon   
            }
        }
    }
}