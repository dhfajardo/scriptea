using scriptea.Lexical;
using scriptea.Parsing.Operators;

namespace scriptea.Parsing.Expressions
{
    public class ShiftExpressionp:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.OpLeftShift
                || parser.CurrenToken.Type == TokenType.OpRightShift
                || parser.CurrenToken.Type == TokenType.OpRightShiftZeroFill)
            {
                new ShiftOperator().Process(parser);
                new AdditiveExpression().Process(parser);
                this.Process(parser);
            }
            else
            {
                //Epsilon
            }
        }
    }
}