using System.Collections.Generic;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Expressions
{
    public class OrExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) new AndExpression().Process(parser, parameters);
            return new OrExpressionp().Process(parser
                , new SortedDictionary<string, object>(){{"LeftNode", _leftNode}});
        }
    }
}