using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Others;

namespace scriptea.Parsing.Expressions.Constructor
{
    public class ConstructorCallp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.PmLeftParent)
            {
                parser.NextToken();
                new ExpressionOpt().Process(parser, parameters);
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
                    this.Process(parser, parameters);
                }
            }
            else
            {
                throw new ParserException("This was expected a Identifier or (");
            }
            return null;
        }
    }
}