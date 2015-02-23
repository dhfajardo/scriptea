using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Expressions;

namespace scriptea.Parsing.Statements.Clause
{
    public class CaseClauseList:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwCase)
            {
                new CaseClause().Process(parser, parameters);
                this.Process(parser, parameters);
            }
            else
            {
                //Epsilon   
            }
            return null;
        }
    }
}