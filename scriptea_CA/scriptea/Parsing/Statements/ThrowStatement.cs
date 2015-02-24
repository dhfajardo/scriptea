using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Expressions.Constructor;

namespace scriptea.Parsing.Statements
{
    public class ThrowStatement:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwThrow)
            {
                parser.NextToken();
                new ThrowStatementp().Process(parser, parameters);
            }
            else
            {
                //Epsilon
                throw new ParserException("This was expected the token: throw, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
            return null;
        }
    }
}