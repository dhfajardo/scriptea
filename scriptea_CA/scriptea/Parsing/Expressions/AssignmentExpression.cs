using System.Collections.Generic;

namespace scriptea.Parsing.Expressions
{
    public  class AssignmentExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            new ConditionalExpression().Process(parser, parameters);
            new AssignmentExpressionp().Process(parser, parameters);
            return null;
        }
    }
}