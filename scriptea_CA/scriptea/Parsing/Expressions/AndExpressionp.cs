using scriptea.Lexical;

namespace scriptea.Parsing.Expressions
{
    public class AndExpressionp:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.OpAnd)
            {
                parser.NextToken();
                new BitwiseOrExpression().Process(parser);
                this.Process(parser);
            }
            else
            {
                //Epsilon
            }
        }
    }
}