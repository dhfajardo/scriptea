using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Operators;

namespace scriptea.Parsing.Expressions
{
    public class MultiplicativeExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            new UnaryExpression().Process(parser, parameters);
            new MultiplicativeExpressionp().Process(parser, parameters);
            return null;
        }
    }
}