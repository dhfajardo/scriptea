using System.Collections.Generic;
using System.Text.RegularExpressions;
using scriptea.Lexical;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Operators;

namespace scriptea.Parsing.Expressions
{
    public class OrExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) parameters["LeftNode"];
            if (parser.CurrenToken.Type == TokenType.OpOr)
            {
                parser.NextToken();
                var _rightNode = (ExpressionNode) new AndExpression().Process(parser, parameters);
                var _or = new OrNode {LeftNode = _leftNode, RightNode = _rightNode};
                return this.Process(parser
                    , new SortedDictionary<string, object>() {{"LeftNode", _or}});
            }
            else
            {
                return _leftNode;
            }
        }
    }
}