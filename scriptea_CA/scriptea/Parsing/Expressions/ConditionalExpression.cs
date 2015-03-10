using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Expressions
{
    public class ConditionalExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) new OrExpression().Process(parser, parameters);
            return new ConditionalExpressionp().Process(parser
                , new SortedDictionary<string, object>(){{"LeftNode",_leftNode}});
        }
    }
}