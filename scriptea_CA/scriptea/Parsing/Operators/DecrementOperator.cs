using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;

namespace scriptea.Parsing.Operators
{
    public class DecrementOperator:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpDec)
            {
                parser.NextToken();
            }
            else
            {
                throw new ParserException("This was expected --");
            }
            return null;
        }
    }
}
