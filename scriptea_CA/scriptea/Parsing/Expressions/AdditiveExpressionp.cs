using scriptea.Lexical;
using scriptea.Parsing.Operators;

namespace scriptea.Parsing.Expressions
{
    public class AdditiveExpressionp:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.OpSum
                || parser.CurrenToken.Type == TokenType.OpSub)
            {
                new AdditiveOperator().Process(parser);
                new MultiplicativeExpression().Process(parser);
                this.Process(parser);
            }
            else
            {
                //Epsilon
            }
        }
    }
}