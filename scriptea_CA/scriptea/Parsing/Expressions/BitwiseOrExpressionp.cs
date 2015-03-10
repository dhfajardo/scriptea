using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Operators;

namespace scriptea.Parsing.Expressions
{
    public class BitwiseOrExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) parameters["LeftNode"];
            if (parser.CurrenToken.Type == TokenType.OpBitwiseOr)
            {
                parser.NextToken();
                var _rightNode = (ExpressionNode) new BitwiseXorExpression().Process(parser, parameters);
                var _bitOr = new BitwiseOrNode {LeftNode = _leftNode, RightNode = _rightNode};
                return this.Process(parser
                    , new SortedDictionary<string, object>() {{"LeftNode", _bitOr}});
            }
            else
            {
                return _leftNode;
            }
        }
    }
}