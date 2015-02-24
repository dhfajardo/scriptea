using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Operators;
using scriptea.Parsing.Expressions.Constructor;

namespace scriptea.Parsing.Expressions
{
    public class UnaryExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                new MemberExpression().Process(parser, parameters);
                new UnaryExpressionp().Process(parser, parameters);
            }
            else if (parser.CurrenToken.Type == TokenType.PmLeftParent
                || parser.CurrenToken.Type == TokenType.PmLeftBracket
                || parser.CurrenToken.Type == TokenType.LitInteger
                || parser.CurrenToken.Type == TokenType.LitString
                || parser.CurrenToken.Type == TokenType.LitFloat
                || parser.CurrenToken.Type == TokenType.LitBool
                || parser.CurrenToken.Type == TokenType.KwNull)
            {
                new PrimaryExpression().Process(parser, parameters);
            }
            else if (parser.CurrenToken.Type == TokenType.OpNot
                     || parser.CurrenToken.Type == TokenType.OpSub
                     || parser.CurrenToken.Type == TokenType.OpNotBit)
            {
                new UnaryOperator().Process(parser, parameters);
                this.Process(parser, parameters);
            }
            else if (parser.CurrenToken.Type == TokenType.OpInc)
            {
                new IncrementOperator().Process(parser, parameters);
                new MemberExpression().Process(parser, parameters);
            }
            else if (parser.CurrenToken.Type == TokenType.OpDec)
            {
                new DecrementOperator().Process(parser, parameters);
                new MemberExpression().Process(parser, parameters);
            }
            else if (parser.CurrenToken.Type == TokenType.KwNew)
            {
                parser.NextToken();
                new ConstructorCall().Process(parser, parameters);
            }
            else
            {
                throw new ParserException("This was expected a UnaryExpresion, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
            return null;
        }
    }
}