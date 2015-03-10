using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Expressions
{
    public class AdditiveExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) new MultiplicativeExpression().Process(parser, parameters);
            return new AdditiveExpressionp().Process(parser
                , new SortedDictionary<string, object>() {{"LeftNode", _leftNode}});
        }
    }
}