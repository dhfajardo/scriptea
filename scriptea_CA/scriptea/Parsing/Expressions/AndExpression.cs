using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Expressions
{
    public class AndExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) new BitwiseOrExpression().Process(parser, parameters);
            return new AndExpressionp().Process(parser
                , new SortedDictionary<string, object>(){{"LeftNode",_leftNode}});
        }
    }
}