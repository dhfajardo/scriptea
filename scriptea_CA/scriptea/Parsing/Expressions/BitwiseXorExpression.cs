using System.Collections.Generic;

namespace scriptea.Parsing.Expressions
{
    public class BitwiseXorExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            new BitwiseAndExpression().Process(parser, parameters);
            new BitwiseXorExpressionp().Process(parser, parameters);
            return null;
        }
    }
}