using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Parameters
{
    public class ParameterListp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.PmComma)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.Id)
                {
                    parser.NextToken();
                    this.Process(parser, parameters);
                }
                else
                {
                    throw new ParserException("This was expected a Identifier in the parameter, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else
            {
                //Epsilon
            }
            return null;
        }
    }
}
