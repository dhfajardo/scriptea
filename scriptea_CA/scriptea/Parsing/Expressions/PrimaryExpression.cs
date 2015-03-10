using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Literals;

namespace scriptea.Parsing.Expressions
{
    public  class PrimaryExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.PmLeftParent)
            {
                parser.NextToken();
                var _resultAssig = (ExpressionNode)new AssignmentExpression().Process(parser, null);
                if (parser.CurrenToken.Type == TokenType.PmRightParent)
                {
                    parser.NextToken();
                    return _resultAssig;
                }
                else
                {
                    throw new ParserException("This was expected ) in the primary expression, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else if (parser.CurrenToken.Type == TokenType.PmLeftBracket)
            {
                parser.NextToken();
                var _resultAssig = (List<ExpressionNode>) new ExpressionOpt().Process(parser, null);
                if (parser.CurrenToken.Type == TokenType.PmRightBracket)
                {
                    parser.NextToken();
                    return new ArrayNode {ElementsArray = _resultAssig};
                }
                else
                {
                    throw new ParserException("This was expected ] in the primary expression, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else if (parser.CurrenToken.Type == TokenType.LitInteger)
            {
                int _value = int.Parse(parser.CurrenToken.LexemeVal);
                parser.NextToken();
                return new IntegerNode {Value = _value};
            }
            else if (parser.CurrenToken.Type == TokenType.LitFloat)
            {
                float _value = float.Parse(parser.CurrenToken.LexemeVal);
                parser.NextToken();
                return new FloatNode {Value = _value};
            }
            else if (parser.CurrenToken.Type == TokenType.LitString)
            {
                string _value = parser.CurrenToken.LexemeVal;
                parser.NextToken();
                return new StringNode {Value = _value};
            }
            else if (parser.CurrenToken.Type == TokenType.LitBool)
            {
                bool _value = bool.Parse(parser.CurrenToken.LexemeVal);
                parser.NextToken();
                return new BooleanNode {Value = _value};
            }
            else if(parser.CurrenToken.Type == TokenType.KwNull)
            {
                parser.NextToken();
                return new NullNode();
            }
            else
            {
                throw new ParserException("This was expected (, [, lit. int,lit. float, lit. bool or null in the primary expression, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
        }
    }
}
