using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Operators;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Operators;

namespace scriptea.Parsing.Expressions
{
    public class RelationalExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) parameters["LeftNode"];
            if (parser.CurrenToken.Type == TokenType.OpGreaterThan
                || parser.CurrenToken.Type == TokenType.OpGreaterEqualThan
                || parser.CurrenToken.Type == TokenType.OpLessThan
                || parser.CurrenToken.Type == TokenType.OpLessEqualThan
                || parser.CurrenToken.Type == TokenType.OpNotEqual
                || parser.CurrenToken.Type == TokenType.OpEquiv
                || parser.CurrenToken.Type == TokenType.OpEqual
                || parser.CurrenToken.Type == TokenType.OpNotEquiv)
            {
                var _relOp = (BinaryOperatorNode) new RelationalOperator().Process(parser, parameters);
                var _rightNode = (ExpressionNode) new ShiftExpression().Process(parser, parameters);
                _relOp.LeftNode = _leftNode;
                _relOp.RightNode = _rightNode;
                return this.Process(parser
                    , new SortedDictionary<string, object>() {{"LeftNode", _relOp}});
            }
            else
            {
                return _leftNode;
            }
        }
    }
}