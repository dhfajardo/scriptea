using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Expressions
{
    public class RelationalExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) new ShiftExpression().Process(parser, parameters);
            return new RelationalExpressionp().Process(parser
                , new SortedDictionary<string, object>() {{"LeftNode", _leftNode}});
        }
    }
}