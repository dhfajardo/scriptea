using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression.Operators.ShiftOperators;

namespace scriptea.Parsing.Operators
{
    public class ShiftOperator:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpLeftShift)
            {
                parser.NextToken();
                return new LeftShiftOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpRightShift)
            {
                parser.NextToken();
                return new RightShiftOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpRightShiftZeroFill)
            {
                parser.NextToken();
                return new RightShiftZeroFillOperatorNode();
            }
            else
            {
                throw new ParserException("This was expected >>,<< or >>>, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
            return null;
        }
    }
}