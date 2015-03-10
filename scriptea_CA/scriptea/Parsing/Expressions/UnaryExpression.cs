using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Operators;
using scriptea.Parsing.Expressions.Constructor;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Operators;
using scriptea.Tree.Expression.Operators.UnaryOperators;

namespace scriptea.Parsing.Expressions
{
    public class UnaryExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            //var _valueEp = (ExpressionNode) parameters["ValueEp"];
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                var _memberEp = new MemberExpression().Process(parser, null);
                return new UnaryExpressionp().Process(parser
                    , new SortedDictionary<string, object>(){{"ValueId", _memberEp}});
            }
            else if (parser.CurrenToken.Type == TokenType.PmLeftParent
                || parser.CurrenToken.Type == TokenType.PmLeftBracket
                || parser.CurrenToken.Type == TokenType.LitInteger
                || parser.CurrenToken.Type == TokenType.LitString
                || parser.CurrenToken.Type == TokenType.LitFloat
                || parser.CurrenToken.Type == TokenType.LitBool
                || parser.CurrenToken.Type == TokenType.KwNull)
            {
                return new PrimaryExpression().Process(parser, null);
            }
            else if (parser.CurrenToken.Type == TokenType.OpNot
                     || parser.CurrenToken.Type == TokenType.OpSub
                     || parser.CurrenToken.Type == TokenType.OpNotBit)
            {
                var _unaryOp = (BaseUnaryOperatorNode) new UnaryOperator().Process(parser, null);
                var _unaryEp = (ExpressionNode) this.Process(parser,null);
                _unaryOp.ValueNode = _unaryEp;
                return _unaryOp;
            }
            else if (parser.CurrenToken.Type == TokenType.OpInc)
            {
                var _incOp = (IncPreOperatorNode) new IncrementOperator().Process(parser
                    , new SortedDictionary<string, object>() {{"Flag", "Pre"}});
                var _memberEp = (ExpressionNode) new MemberExpression().Process(parser, null);
                _incOp.ValueNode =  _memberEp;
                return _incOp;
            }
            else if (parser.CurrenToken.Type == TokenType.OpDec)
            {
                var _decOp = (DecPreOperatorNode) new DecrementOperator().Process(parser
                    , new SortedDictionary<string, object>() {{"Flag", "Pre"}});
                var _memberEp = (ExpressionNode) new MemberExpression().Process(parser, null);
                _decOp.ValueNode =  _memberEp;
                return _decOp;
            }
            else if (parser.CurrenToken.Type == TokenType.KwNew)
            {
                parser.NextToken();
                return new ConstructorCall().Process(parser, parameters);
            }
            else
            {
                throw new ParserException("This was expected a UnaryExpresion, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
        }
    }
}