using scriptea.Lexical;

namespace scriptea.Parsing.Variables
{
    public class VariableList:INTerminal
    {
        public void Process(Parser parser)
        {
            new Variable().Process(parser);
            new VariableListp().Process(parser);
        }
    }
}