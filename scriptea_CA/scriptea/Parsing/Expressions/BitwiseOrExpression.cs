using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Expressions
{
    public class BitwiseOrExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) new BitwiseXorExpression().Process(parser, parameters);
            return new BitwiseOrExpressionp().Process(parser
                , new SortedDictionary<string, object>(){{"LeftNode",_leftNode}});
        }
    }
}