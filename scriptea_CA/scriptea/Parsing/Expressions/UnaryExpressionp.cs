using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;
using scriptea.Parsing.Operators;

namespace scriptea.Parsing.Expressions
{
    public class UnaryExpressionp:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.OpInc)
            {
                new IncrementOperator().Process(parser);
            }
            else if (parser.CurrenToken.Type == TokenType.OpDec)
            {
                new DecrementOperator().Process(parser);
            }
            else
            {
                //Epsilon
            }
        }
    }
}
