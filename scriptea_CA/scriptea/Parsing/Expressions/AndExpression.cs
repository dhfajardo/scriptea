namespace scriptea.Parsing.Expressions
{
    public class AndExpression:INTerminal
    {
        public void Process(Parser parser)
        {
            new BitwiseOrExpression().Process(parser);
            new AndExpressionp().Process(parser);
        }
    }
}