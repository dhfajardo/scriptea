using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;
using scriptea.Parsing.Operators;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Operators;
using scriptea.Tree.Expression.Operators.UnaryOperators;

namespace scriptea.Parsing.Expressions
{
    public class UnaryExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _id = (ExpressionNode) parameters["ValueId"];
            if (parser.CurrenToken.Type == TokenType.OpInc)
            {
                var _incOp = (BaseUnaryOperatorNode) new IncrementOperator().Process(parser
                    , new SortedDictionary<string, object>() {{"Flag", "Pos"}});
                _incOp.ValueNode = _id;
                return _incOp;
            }
            else if (parser.CurrenToken.Type == TokenType.OpDec)
            {
                var _decOp = (BaseUnaryOperatorNode) new DecrementOperator().Process(parser
                    , new SortedDictionary<string, object>(){{"Flag","Pos"}});
                _decOp.ValueNode = _id;
                return _decOp;
            }
            else
            {
                return _id;
            }
        }
    }
}
