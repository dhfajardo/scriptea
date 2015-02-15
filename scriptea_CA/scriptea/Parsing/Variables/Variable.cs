using scriptea.Lexical;
using scriptea.Parsing.Expressions;

namespace scriptea.Parsing.Variables
{
    public class Variable:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                parser.NextToken();
                new Variablep().Process(parser);
            }
            else
            {
                throw  new ParserException("This was expected a Identifier");
            }
        }
    }
}