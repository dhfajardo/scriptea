using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;
using scriptea.Parsing.Others;

namespace scriptea.Parsing.Expressions
{
    public class MemberExpression:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                parser.NextToken();
                new AccesorList().Process(parser);
            }
            else
            {
                throw new ParserException("This was expected a Identifier");
            }
        }
    }
}
