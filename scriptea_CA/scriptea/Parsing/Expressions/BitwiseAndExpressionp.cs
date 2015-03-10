using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Operators;

namespace scriptea.Parsing.Expressions
{
    public class BitwiseAndExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) parameters["LeftNode"];
            if (parser.CurrenToken.Type == TokenType.OpBitwiseAnd)
            {
                parser.NextToken();
                var _rightNode = (ExpressionNode) new RelationalExpression().Process(parser, parameters);
                var _bitAnd = new BitwiseAndNode {LeftNode = _leftNode, RightNode = _rightNode};
                return this.Process(parser
                    , new SortedDictionary<string, object>() {{"LeftNode", _bitAnd}});
            }
            else
            {
                return _leftNode;
            }
        }
    }
}
