using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Operators
{
    public class IncrementOperator:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpInc)
            {
                parser.NextToken();
            }
            else
            {
                throw new LexerException("This was expected ++");
            }
            return null;
        }
    }
}