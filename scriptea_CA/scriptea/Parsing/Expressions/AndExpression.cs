using System.Collections.Generic;

namespace scriptea.Parsing.Expressions
{
    public class AndExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            new BitwiseOrExpression().Process(parser, parameters);
            new AndExpressionp().Process(parser, parameters);
            return null;
        }
    }
}