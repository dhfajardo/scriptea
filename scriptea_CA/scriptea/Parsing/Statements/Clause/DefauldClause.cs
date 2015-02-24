using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Statements.Clause
{
    public class DefauldClause:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwDefault)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.PmColon)
                {
                    parser.NextToken();
                    new Statementp().Process(parser, parameters);
                    new CaseClauseList().Process(parser, parameters);
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
            return null;
        }
    }
}