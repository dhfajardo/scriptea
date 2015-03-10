using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Operators;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Operators;

namespace scriptea.Parsing.Expressions
{
    public class AdditiveExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) parameters["LeftNode"];
            if (parser.CurrenToken.Type == TokenType.OpSum
                || parser.CurrenToken.Type == TokenType.OpSub)
            {
                var _addOp = (BinaryOperatorNode) new AdditiveOperator().Process(parser, parameters);
                var _rightNode = (ExpressionNode) new MultiplicativeExpression().Process(parser, parameters);
                _addOp.LeftNode = _leftNode;
                _addOp.RightNode = _rightNode;
                return this.Process(parser
                    , new SortedDictionary<string, object>() {{"LeftNode", _addOp}});
            }
            else
            {
                return _leftNode;
            }
        }
    }
}