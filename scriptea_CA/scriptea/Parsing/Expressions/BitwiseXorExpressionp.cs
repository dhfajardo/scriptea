using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Operators;

namespace scriptea.Parsing.Expressions
{
    public class BitwiseXorExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) parameters["LeftNode"];
            if (parser.CurrenToken.Type == TokenType.OpBitwiseXOr)
            {
                parser.NextToken();
                var _rightNode = (ExpressionNode) new BitwiseAndExpression().Process(parser, parameters);
                var _bitXOr = new BitwiseXOrNode {LeftNode = _leftNode, RightNode = _rightNode};
                return this.Process(parser
                    , new SortedDictionary<string, object>() {{"LeftNode", _bitXOr}});
            }
            else
            {
                return _leftNode;
            }
        }
    }
}