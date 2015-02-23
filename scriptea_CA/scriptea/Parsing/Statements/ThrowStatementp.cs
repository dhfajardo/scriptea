using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Expressions.Constructor;

namespace scriptea.Parsing.Statements
{
    public class ThrowStatementp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.KwNew)
            {
                parser.NextToken();
                new ConstructorCall().Process(parser, parameters);
            }
            else
            {
                //Epsilon
            }
            return null;
        }
    }
}
