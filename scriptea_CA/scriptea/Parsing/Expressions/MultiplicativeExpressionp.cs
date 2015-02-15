using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;
using scriptea.Parsing.Operators;

namespace scriptea.Parsing.Expressions
{
    public class MultiplicativeExpressionp:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.OpMul
                || parser.CurrenToken.Type == TokenType.OpDiv
                || parser.CurrenToken.Type == TokenType.OpMod)
            {
                new MultiplicativeOperator().Process(parser);
                new UnaryExpression().Process(parser);
                this.Process(parser);
            }
            else
            {
                //Epsilon
            }
        }
    }
}
