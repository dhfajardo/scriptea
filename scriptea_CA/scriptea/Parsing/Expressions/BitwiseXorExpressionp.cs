using scriptea.Lexical;

namespace scriptea.Parsing.Expressions
{
    public class BitwiseXorExpressionp:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.OpBitwiseXOr)
            {
                parser.NextToken();
                new BitwiseAndExpression().Process(parser);
                this.Process(parser);
            }
            else
            {
                //Epsilon
            }
        }
    }
}