namespace scriptea.Parsing.Expressions
{
    public class BitwiseXorExpression:INTerminal
    {
        public void Process(Parser parser)
        {
            new BitwiseAndExpression().Process(parser);
            new BitwiseXorExpressionp().Process(parser);
        }
    }
}