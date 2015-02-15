namespace scriptea.Parsing.Expressions
{
    public class BitwiseOrExpression:INTerminal
    {
        public void Process(Parser parser)
        {
            new BitwiseXorExpression().Process(parser);
            new BitwiseOrExpressionp().Process(parser);
        }
    }
}