using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Statements.Elements
{
    public class IfNot:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwElse)
            {
                parser.NextToken();
                new Statementp().Process(parser, parameters);
            }
            else
            {
                //Epsilon
            }
            return null;
        }
    }
}
