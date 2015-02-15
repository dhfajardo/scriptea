namespace scriptea.Parsing.Expressions
{
    public class RelationalExpression:INTerminal
    {
        public void Process(Parser parser)
        {
            new ShiftExpression().Process(parser);
            new RelationalExpressionp().Process(parser);
        }
    }
}