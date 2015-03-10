using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Operators;

namespace scriptea.Parsing.Expressions
{
    public class AndExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) parameters["LeftNode"];
            if (parser.CurrenToken.Type == TokenType.OpAnd)
            {
                parser.NextToken();
                var _rightNode = (ExpressionNode) new BitwiseOrExpression().Process(parser, parameters);
                var _and  = new AndNode {LeftNode = _leftNode, RightNode = _rightNode};
                return this.Process(parser
                    , new SortedDictionary<string, object>() {{"LeftNode", _and}});
            }
            else
            {
                return _leftNode;
            }
        }
    }
}