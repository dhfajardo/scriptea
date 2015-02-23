using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;

namespace scriptea.Parsing.Operators
{
    public class UnaryOperator:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpNotBit)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpNot)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpSub)
            {
                parser.NextToken();
            }
            else
            {
                throw  new ParserException("This was expected !,~ or -");
            }
            return null;
        }
    }
}
