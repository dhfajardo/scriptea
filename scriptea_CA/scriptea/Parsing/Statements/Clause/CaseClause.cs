using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;
using scriptea.Parsing.Expressions;

namespace scriptea.Parsing.Statements.Clause
{
    public class CaseClause:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwCase)
            {
                parser.NextToken();
                new AssignmentExpression().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.PmColon)
                {
                    parser.NextToken();
                    new StatementList().Process(parser, parameters);
                }
                else
                {
                    throw new ParserException("This was expected : in the case clause, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else
            {
                throw new ParserException("This was expected the tokent: case, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
            return null;
        }
    }
}
