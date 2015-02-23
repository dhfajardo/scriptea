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
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpMul
                || parser.CurrenToken.Type == TokenType.OpDiv
                || parser.CurrenToken.Type == TokenType.OpMod)
            {
                new MultiplicativeOperator().Process(parser, parameters);
                new UnaryExpression().Process(parser, parameters);
                this.Process(parser, parameters);
            }
            else
            {
                //Epsilon
            }
            return null;
        }
    }
}
