using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Operators;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Expressions
{
    public class MultiplicativeExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) new UnaryExpression().Process(parser, parameters);
            return new MultiplicativeExpressionp().Process(parser
                , new SortedDictionary<string, object>() {{"LeftNode", _leftNode}});
        }
    }
}