namespace scriptea.Parsing.Expressions
{
    public class BitwiseAndExpression:INTerminal
    {
        public void Process(Parser parser)
        {
            new RelationalExpression().Process(parser);
            new BitwiseAndExpressionp().Process(parser);
        }
    }
}