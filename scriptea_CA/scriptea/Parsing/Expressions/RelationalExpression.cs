using System.Collections.Generic;

namespace scriptea.Parsing.Expressions
{
    public class RelationalExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            new ShiftExpression().Process(parser, parameters);
            new RelationalExpressionp().Process(parser, parameters);
            return null;
        }
    }
}