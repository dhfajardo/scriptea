using scriptea.Lexical;

namespace scriptea.Parsing.Expressions
{
    public class ConditionalExpressionp:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.OpTernary)
            {
                parser.NextToken();
                new AssignmentExpression().Process(parser);
                if (parser.CurrenToken.Type == TokenType.PmColon)
                {
                    parser.NextToken();
                    new AssignmentExpression().Process(parser);
                }
                else
                {
                    throw new ParserException("This was expected :");
                }
            }
            else
            {
                //Epsilon
            }
        }
    }
}