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
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.KwCase)
            {
                parser.NextToken();
                new AssignmentExpression().Process(parser);
                if (parser.CurrenToken.Type == TokenType.PmColon)
                {
                    parser.NextToken();
                    new StatementList().Process(parser);
                }
                else
                {
                    throw new ParserException("This was expected :");
                }
            }
            else
            {
                throw new ParserException("This was expected the word case");
            }
        }
    }
}
