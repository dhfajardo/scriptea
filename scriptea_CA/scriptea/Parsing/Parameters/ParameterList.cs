using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Parameters
{
    public class ParameterList:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                parser.NextToken();
                new ParameterListp().Process(parser, parameters);
            }
            else
            {
                throw new ParserException("This was expected a Identifier in the parameter, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
            return null;
        }
    }
}