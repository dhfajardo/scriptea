using System.Collections.Generic;

namespace scriptea.Parsing.Expressions
{
    public class ShiftExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            new AdditiveExpression().Process(parser, parameters);
            new ShiftExpressionp().Process(parser, parameters);
            return null;
        }
    }
}