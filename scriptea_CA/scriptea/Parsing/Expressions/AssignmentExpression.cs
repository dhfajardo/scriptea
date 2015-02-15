namespace scriptea.Parsing.Expressions
{
    public  class AssignmentExpression:INTerminal
    {
        public void Process(Parser parser)
        {
            new ConditionalExpression().Process(parser);
            new AssignmentExpressionp().Process(parser);
        }
    }
}