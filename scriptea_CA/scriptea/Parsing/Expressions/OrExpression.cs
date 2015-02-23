using System.Collections.Generic;

namespace scriptea.Parsing.Expressions
{
    public class OrExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            new AndExpression().Process(parser, parameters);
            new OrExpressionp().Process(parser, parameters);
            return null;
        }
    }
}