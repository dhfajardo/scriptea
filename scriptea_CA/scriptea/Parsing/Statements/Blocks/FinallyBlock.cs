using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Statements.Blocks
{
    public class FinallyBlock:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwFinally)
            {
                parser.NextToken();
                new CompoundStatement().Process(parser, parameters);
            }
            else
            {
                //Epsilon
            }
            return null;
        }
    }
}