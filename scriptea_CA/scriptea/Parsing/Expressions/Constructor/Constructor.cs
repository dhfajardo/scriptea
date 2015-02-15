using scriptea.Lexical;

namespace scriptea.Parsing.Expressions.Constructor
{
    public class Constructor:INTerminal
    {
        public void Process(Parser parser)
        {
            new ConstructorCall().Process(parser);
        }
    }
}