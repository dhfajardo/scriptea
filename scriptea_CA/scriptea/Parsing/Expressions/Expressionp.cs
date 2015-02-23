using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Expressions
{
    public class Expressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.PmComma)
            {
                parser.NextToken();
                new AssignmentExpression().Process(parser, parameters);
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