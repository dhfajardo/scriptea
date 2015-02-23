using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Operators
{
    public class ShiftOperator:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpLeftShift)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpRightShift)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpRightShiftZeroFill)
            {
                parser.NextToken();
            }
            else
            {
                throw  new ParserException("This was expected >>,<< or >>>");
            }
            return null;
        }
    }
}