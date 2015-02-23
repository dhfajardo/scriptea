using System.Collections.Generic;

namespace scriptea.Parsing.Expressions
{
    public class BitwiseOrExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            new BitwiseXorExpression().Process(parser, parameters);
            new BitwiseOrExpressionp().Process(parser, parameters);
            return null;
        }
    }
}