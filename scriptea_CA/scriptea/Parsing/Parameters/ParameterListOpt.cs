using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Parameters
{
    public class ParameterListOpt:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                new ParameterList().Process(parser, parameters);
            }
            else
            {
               //Epsilon
            }
            return null;
        }
    }
}