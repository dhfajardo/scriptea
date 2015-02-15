namespace scriptea.Parsing.Expressions
{
    public class ConditionalExpression:INTerminal
    {
        public void Process(Parser parser)
        {
            new OrExpression().Process(parser);
            new ConditionalExpressionp().Process(parser);
        }
    }
}