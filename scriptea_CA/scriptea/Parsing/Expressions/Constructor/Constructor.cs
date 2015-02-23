using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using scriptea.Lexical;

namespace scriptea.Parsing.Expressions.Constructor
{
    public class Constructor:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            new ConstructorCall().Process(parser, parameters);
            return null;
        }
    }
}