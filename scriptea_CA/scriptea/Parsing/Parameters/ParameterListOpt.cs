using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Parameters
{
    public class ParameterListOpt:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                return new ParameterList().Process(parser, parameters);
            }
            else
            {
                return new List<IdNode>();
            }
        }
    }
}