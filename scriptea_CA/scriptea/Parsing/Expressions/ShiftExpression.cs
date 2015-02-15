namespace scriptea.Parsing.Expressions
{
    public class ShiftExpression:INTerminal
    {
        public void Process(Parser parser)
        {
            new AdditiveExpression().Process(parser);
            new ShiftExpressionp().Process(parser);
        }
    }
}