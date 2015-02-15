using scriptea.Lexical;

namespace scriptea.Parsing.Expressions
{
    public class Expressionp:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.PmComma)
            {
                parser.NextToken();
                new AssignmentExpression().Process(parser);
                this.Process(parser);
            }
            else
            {
                //Epsilon
            }
        }
    }
}