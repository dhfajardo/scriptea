using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Statements
{
    public class CompoundStatement:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.PmLeftCurlyBracket)
            {
                parser.NextToken();
                new StatementList().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.PmRightCurlyBracket)
                {
                    parser.NextToken();
                }
                else
                {
                    throw new ParserException("This was expected }");
                }
            }
            else
            {
                throw new ParserException("This was expected {");
            }
            return null;
        }
    }
}