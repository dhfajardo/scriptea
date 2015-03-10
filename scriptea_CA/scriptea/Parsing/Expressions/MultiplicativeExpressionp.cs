using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;
using scriptea.Parsing.Operators;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Operators;

namespace scriptea.Parsing.Expressions
{
    public class MultiplicativeExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) parameters["LeftNode"];
            if (parser.CurrenToken.Type == TokenType.OpMul
                || parser.CurrenToken.Type == TokenType.OpDiv
                || parser.CurrenToken.Type == TokenType.OpMod)
            {
                var _mulOp = (BinaryOperatorNode) new MultiplicativeOperator().Process(parser, parameters);
                var _rightNode = (ExpressionNode) new UnaryExpression().Process(parser, parameters);
                _mulOp.LeftNode = _leftNode;
                _mulOp.RightNode = _rightNode;
                return this.Process(parser
                    , new SortedDictionary<string, object>() {{"LeftNode", _mulOp}});
            }
            else
            {
                return _leftNode;
            }
        }
    }
}
