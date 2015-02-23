using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Expressions
{
    public class ConditionalExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpTernary)
            {
                parser.NextToken();
                new AssignmentExpression().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.PmColon)
                {
                    parser.NextToken();
                    new AssignmentExpression().Process(parser, parameters);
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