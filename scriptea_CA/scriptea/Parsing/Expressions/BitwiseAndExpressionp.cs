using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;

namespace scriptea.Parsing.Expressions
{
    public class BitwiseAndExpressionp:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.OpBitwiseAnd)
            {
                parser.NextToken();
                new RelationalExpression().Process(parser);
                this.Process(parser);
            }
            else
            {
                //Epsilon
            }
        }
    }
}
