using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Operators;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Operators;

namespace scriptea.Parsing.Expressions
{
    public class ShiftExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) parameters["LeftNode"];
            if (parser.CurrenToken.Type == TokenType.OpLeftShift
                || parser.CurrenToken.Type == TokenType.OpRightShift
                || parser.CurrenToken.Type == TokenType.OpRightShiftZeroFill)
            {
                var _shiftOp =(BinaryOperatorNode)new ShiftOperator().Process(parser, parameters);
                var _rightNode =(ExpressionNode) new AdditiveExpression().Process(parser, parameters);
                _shiftOp.LeftNode = _leftNode;
                _shiftOp.RightNode = _rightNode;
                return this.Process(parser
                    , new SortedDictionary<string, object>() {{"LeftNode", _shiftOp}});
            }
            else
            {
                return _leftNode;
            }
        }
    }
}