using System.Collections.Generic;

namespace scriptea.Parsing.Expressions
{
    public class BitwiseAndExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            new RelationalExpression().Process(parser, parameters);
            new BitwiseAndExpressionp().Process(parser, parameters);
            return null;
        }
    }
}