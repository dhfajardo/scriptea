namespace scriptea.Parsing.Expressions
{
    public class AdditiveExpression:INTerminal
    {
        public void Process(Parser parser)
        {
            new MultiplicativeExpression().Process(parser);
            new AdditiveExpressionp().Process(parser);
        }
    }
}