using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Operators;

namespace scriptea.Parsing.Expressions
{
    public class ShiftExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpLeftShift
                || parser.CurrenToken.Type == TokenType.OpRightShift
                || parser.CurrenToken.Type == TokenType.OpRightShiftZeroFill)
            {
                new ShiftOperator().Process(parser, parameters);
                new AdditiveExpression().Process(parser, parameters);
                this.Process(parser, parameters);
            }
            else
            {
                //Epsilon
            }
            return null;
        }
    }
}