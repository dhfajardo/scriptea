using scriptea.Lexical;
using scriptea.Parsing.Expressions;

namespace scriptea.Parsing.Variables
{
    public class VariablesOrExpression:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.KwVar)
            {
                parser.NextToken();
                new VariableList().Process(parser);
            }
            else
            {
                new Expression().Process(parser);
            }
        }
    }
}