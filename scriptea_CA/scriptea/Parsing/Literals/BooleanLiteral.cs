using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;

namespace scriptea.Parsing.Literals
{
    public  class BooleanLiteral:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.LitBool)
            {
                parser.NextToken();
            }
            else
            {
                throw  new ParserException("This was expected a literal boolean");
            }
        }
    }
}
