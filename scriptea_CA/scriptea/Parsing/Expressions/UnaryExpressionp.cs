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
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpInc)
            {
                new IncrementOperator().Process(parser, parameters);
            }
            else if (parser.CurrenToken.Type == TokenType.OpDec)
            {
                new DecrementOperator().Process(parser, parameters);
            }
            else
            {
                //Epsilon
            }
            return null;
        }
    }
}
