using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Expressions.Constructor
{
    public class ConstructorCall:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                parser.NextToken();
                new ConstructorCallp().Process(parser, parameters);
            }
            else
            {
                throw new ParserException("This was expected Identifier in constructor call, Received: " + 
                    parser.CurrenToken.LexemeVal + ", Row: " + parser.CurrenToken.Row
                    + ", Column: " + parser.CurrenToken.Column);
            }
            return null;
        }
    }
}