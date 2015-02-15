namespace scriptea.Parsing.Expressions
{
    public class OrExpression:INTerminal
    {
        public void Process(Parser parser)
        {
            new AndExpression().Process(parser);
            new OrExpressionp().Process(parser);
        }
    }
}