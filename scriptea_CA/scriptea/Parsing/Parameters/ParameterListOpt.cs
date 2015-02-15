using scriptea.Lexical;

namespace scriptea.Parsing.Parameters
{
    public class ParameterListOpt:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                new ParameterList().Process(parser);
            }
            else
            {
               //Epsilon
            }
        }
    }
}