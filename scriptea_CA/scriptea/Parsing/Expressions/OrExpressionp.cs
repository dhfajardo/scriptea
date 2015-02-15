using scriptea.Lexical;

namespace scriptea.Parsing.Expressions
{
    public class OrExpressionp:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.OpOr)
            {
                parser.NextToken();
                new AndExpression().Process(parser);
                this.Process(parser);
            }
            else
            {
                //Epsilon
            }
        }
    }
}