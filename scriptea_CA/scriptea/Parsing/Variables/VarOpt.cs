using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Variables
{
    public class VarOpt:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwVar)
            {
                parser.NextToken();
            }
            else
            {
                //Epsilon
            }
            return null;
        }
    }
}