using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Expressions
{
    public class Expression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            new AssignmentExpression().Process(parser, parameters);
            new Expressionp().Process(parser, parameters);
            return null;
        }
    }
}