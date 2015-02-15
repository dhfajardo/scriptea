using scriptea.Lexical;

namespace scriptea.Parsing.Variables
{
    public class VarOpt:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.KwVar)
            {
                parser.NextToken();
            }
            else
            {
                //Epsilon
            }
        }
    }
}