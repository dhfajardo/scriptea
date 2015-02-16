using scriptea.Lexical;
using scriptea.Parsing.Others;

namespace scriptea.Parsing.Expressions.Constructor
{
    public class ConstructorCallp:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.PmLeftParent)
            {
                parser.NextToken();
                new ExpressionOpt().Process(parser);
                if (parser.CurrenToken.Type == TokenType.PmRightParent)
                {
                    parser.NextToken();
                }
                else
                {
                    throw new ParserException("This was expected Identifier");
                }
            }
            else if (parser.CurrenToken.Type == TokenType.PmDot)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.Id)
                {
                    parser.NextToken();
                    this.Process(parser);
                }
            }
            else
            {
                throw new ParserException("This was expected a Identifier or (");
            }
        }
    }
}