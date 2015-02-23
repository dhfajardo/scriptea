using System.Collections.Generic;

namespace scriptea.Parsing.Expressions
{
    public class ConditionalExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            new OrExpression().Process(parser, parameters);
            new ConditionalExpressionp().Process(parser, parameters);
            return null;
        }
    }
}