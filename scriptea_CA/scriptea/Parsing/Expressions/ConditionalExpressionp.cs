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
                if (parser.CurrenToken.Type == TokenType.PmDot)
                {
                    parser.NextToken();
                    this.Process(parser);
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