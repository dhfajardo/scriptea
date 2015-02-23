using System.Collections.Generic;

namespace scriptea.Parsing.Expressions
{
    public class AdditiveExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            new MultiplicativeExpression().Process(parser, parameters);
            new AdditiveExpressionp().Process(parser, parameters);
            return null;
        }
    }
}