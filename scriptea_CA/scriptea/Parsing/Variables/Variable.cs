using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Expressions;

namespace scriptea.Parsing.Variables
{
    public class Variable:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                parser.NextToken();
                new Variablep().Process(parser, parameters);
            }
            else
            {
                throw  new ParserException("This was expected a Identifier");
            }
            return null;
        }
    }
}