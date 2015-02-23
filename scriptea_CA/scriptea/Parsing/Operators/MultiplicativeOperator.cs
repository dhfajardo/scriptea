using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Operators
{
    public class MultiplicativeOperator:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpMul)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpDiv)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpMod)
            {
                parser.NextToken();
            }
            else
            {
                throw  new ParserException("This was expected *,/ or %");
            }
            return null;
        }
    }
}