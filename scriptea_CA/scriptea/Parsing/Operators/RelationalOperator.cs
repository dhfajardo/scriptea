using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Operators
{
    public class RelationalOperator:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpGreaterThan)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpLessThan)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpGreaterEqualThan)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpLessEqualThan)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpEqual)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpEquiv)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.OpNotEquiv)
            {
                parser.NextToken();
            } 
            else if (parser.CurrenToken.Type == TokenType.OpNotEqual)
            {
                parser.NextToken();
            }
            else
            {
                throw new ParserException("This was expected *,/ or %, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
            return null;
        }
    }
}