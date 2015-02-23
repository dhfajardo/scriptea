using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Statements
{
    public class Statementp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.PmLeftCurlyBracket)
            {
                new CompoundStatement().Process(parser, parameters);
            }
            else
            {
                new Statement().Process(parser, parameters);
            }
            return null;
        }
    }
}
