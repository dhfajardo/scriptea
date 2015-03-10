using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Expressions
{
    public class ShiftExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) new AdditiveExpression().Process(parser, parameters);
            return new ShiftExpressionp().Process(parser
                , new SortedDictionary<string, object>() {{"LeftNode", _leftNode}});
        }
    }
}