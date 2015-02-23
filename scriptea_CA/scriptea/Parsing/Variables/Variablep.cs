using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;
using scriptea.Parsing.Expressions;

namespace scriptea.Parsing.Variables
{
    public class Variablep:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpAssig)
            {
                parser.NextToken();
                new AssignmentExpression().Process(parser, parameters);
            }
            else
            {
                //Epsilon
            }
            return null;
        }
    }
}
