using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Expressions
{
    public class BitwiseAndExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) new RelationalExpression().Process(parser, parameters);
            return new BitwiseAndExpressionp().Process(parser
                , new SortedDictionary<string, object>() {{"LeftNode", _leftNode}});
        }
    }
}