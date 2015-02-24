using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;

namespace scriptea.Parsing.Literals
{
    public  class BooleanLiteral:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.LitBool)
            {
                parser.NextToken();
            }
            else
            {
                throw new ParserException("This was expected a literal boolean, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
            return null;
        }
    }
}
