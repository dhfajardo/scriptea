using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Expressions
{
    public  class AssignmentExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _condEp = (ExpressionNode) new ConditionalExpression().Process(parser, parameters);
            return new AssignmentExpressionp().Process(parser
                , new SortedDictionary<string, object>() { { "LeftNode", _condEp } });

        }
    }
}