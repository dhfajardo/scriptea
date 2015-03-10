using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Operators;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Operators;

namespace scriptea.Parsing.Expressions
{
    public class AssignmentExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) parameters["LeftNode"];
            if (parser.CurrenToken.Type == TokenType.OpAssig
                || parser.CurrenToken.Type == TokenType.OpAssigMul
                || parser.CurrenToken.Type == TokenType.OpAssigDiv
                || parser.CurrenToken.Type == TokenType.OpAssigMod
                || parser.CurrenToken.Type == TokenType.OpAssigSum
                || parser.CurrenToken.Type == TokenType.OpAssigSub
                || parser.CurrenToken.Type == TokenType.OpAssigLeftShift
                || parser.CurrenToken.Type == TokenType.OpAssigRightShift
                || parser.CurrenToken.Type == TokenType.OpAssigRightShiftZeroFill
                || parser.CurrenToken.Type == TokenType.OpAssigBitwiseAnd
                || parser.CurrenToken.Type == TokenType.OpAssigBitwiseOr
                || parser.CurrenToken.Type == TokenType.OpAssigBitwiseXOr)
            {
                var _assigOp = (BaseAssigOperatorNode) new AssignmentOperator().Process(parser, parameters);
                var _rightNode = (ExpressionNode) new ConditionalExpression().Process(parser, parameters);
                _assigOp.LeftNode = _leftNode;
                _assigOp.RightNode = _rightNode;
                return this.Process(parser
                    , new SortedDictionary<string, object>(){{"LeftNode",_assigOp}} );
            }
            else
            {
                return _leftNode;
            }
        }
    }
}