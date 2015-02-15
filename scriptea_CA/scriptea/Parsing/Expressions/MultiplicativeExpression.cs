using scriptea.Lexical;
using scriptea.Parsing.Operators;

namespace scriptea.Parsing.Expressions
{
    public class MultiplicativeExpression:INTerminal
    {
        public void Process(Parser parser)
        {
            new UnaryExpression().Process(parser);
            new MultiplicativeExpressionp().Process(parser);
        }
    }
}