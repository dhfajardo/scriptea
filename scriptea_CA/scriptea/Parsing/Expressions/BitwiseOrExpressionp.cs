using scriptea.Lexical;

namespace scriptea.Parsing.Expressions
{
    public class BitwiseOrExpressionp:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.OpBitwiseOr)
            {
                parser.NextToken();
                new BitwiseXorExpression().Process(parser);
                this.Process(parser);
            }
            else
            {
                //Epsilon
            }
        }
    }
}