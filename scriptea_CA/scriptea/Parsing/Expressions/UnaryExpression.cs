using scriptea.Lexical;
using scriptea.Parsing.Operators;
using scriptea.Parsing.Expressions.Constructor;

namespace scriptea.Parsing.Expressions
{
    public class UnaryExpression:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                new MemberExpression().Process(parser);
                new UnaryExpressionp().Process(parser);
            }
            else if (parser.CurrenToken.Type == TokenType.PmLeftParent
                || parser.CurrenToken.Type == TokenType.PmLeftBracket
                || parser.CurrenToken.Type == TokenType.LitInteger
                || parser.CurrenToken.Type == TokenType.LitString
                || parser.CurrenToken.Type == TokenType.LitFloat
                || parser.CurrenToken.Type == TokenType.LitBool
                || parser.CurrenToken.Type == TokenType.KwNull)
            {
                new PrimaryExpression().Process(parser);
            }
            else if (parser.CurrenToken.Type == TokenType.OpNot
                     || parser.CurrenToken.Type == TokenType.OpSub
                     || parser.CurrenToken.Type == TokenType.OpNotBit)
            {
                new UnaryOperator().Process(parser);
                this.Process(parser);
            }
            else if (parser.CurrenToken.Type == TokenType.OpInc)
            {
                new IncrementOperator().Process(parser);
                new MemberExpression().Process(parser);
            }
            else if (parser.CurrenToken.Type == TokenType.OpDec)
            {
                new DecrementOperator().Process(parser);
                new MemberExpression().Process(parser);
            }
            else if (parser.CurrenToken.Type == TokenType.KwNew)
            {
                parser.NextToken();
                new ConstructorCall().Process(parser);
            }
            else
            {
                //Epsilon
            }
        }
    }
}