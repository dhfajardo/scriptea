using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Expressions;

namespace scriptea.Parsing.Variables
{
    public class VariablesOrExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwVar)
            {
                parser.NextToken();
                new VariableList().Process(parser, parameters);
            }
            else
            {
                new Expression().Process(parser, parameters);
            }
            return null;
        }
    }
}