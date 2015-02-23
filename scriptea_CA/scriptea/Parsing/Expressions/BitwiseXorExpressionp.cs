using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Expressions
{
    public class BitwiseXorExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpBitwiseXOr)
            {
                parser.NextToken();
                new BitwiseAndExpression().Process(parser, parameters);
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