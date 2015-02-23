using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Variables
{
    public class VariableList:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            new Variable().Process(parser, parameters);
            new VariableListp().Process(parser, parameters);
            return null;
        }
    }
}