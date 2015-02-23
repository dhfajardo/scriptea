using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;

namespace scriptea.Parsing.Expressions
{
    public class BitwiseAndExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpBitwiseAnd)
            {
                parser.NextToken();
                new RelationalExpression().Process(parser, parameters);
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
