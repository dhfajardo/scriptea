using scriptea.Lexical;

namespace scriptea.Parsing.Expressions
{
    public class Expression:INTerminal
    {
        public void Process(Parser parser)
        {
            new AssignmentExpression().Process(parser);
            new Expressionp().Process(parser);
        }
    }
}