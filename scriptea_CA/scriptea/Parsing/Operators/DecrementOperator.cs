using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;

namespace scriptea.Parsing.Operators
{
    public class DecrementOperator:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.OpDec)
            {
                parser.NextToken();
            }
            else
            {
                throw new LexerException("This was expected --");
            }

        }
    }
}
