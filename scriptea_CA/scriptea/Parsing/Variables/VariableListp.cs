using scriptea.Lexical;
using scriptea.Parsing.Expressions;

namespace scriptea.Parsing.Variables
{
    public class VariableListp:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.PmComma)
            {
                parser.NextToken();
                new Variable().Process(parser);
                this.Process(parser);
            }
            else
            {
                //Epsilon
            }
        }
    }
}