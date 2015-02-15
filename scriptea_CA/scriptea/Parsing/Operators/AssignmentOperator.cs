using scriptea.Lexical;

namespace scriptea.Parsing.Operators
{
    public class AssignmentOperator:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.OpAssig)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigDiv)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigMul)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigMod)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigSum)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigSub)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigLeftShift)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigRightShift)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigRightShiftZeroFill)
            {
                parser.NextToken();
            }
            else
            {
                throw  new ParserException("This was expected *,/ or %");
            }
        }
    }
}