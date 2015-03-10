using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Expressions
{
    public class BitwiseXorExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) new BitwiseAndExpression().Process(parser, parameters);
            return new BitwiseXorExpressionp().Process(parser
                , new SortedDictionary<string, object>(){{"LeftNode",_leftNode}});
        }
    }
}