using scriptea.Lexical;
using scriptea.Parsing.Parameters;
using scriptea.Parsing.Statements;

namespace scriptea.Parsing
{
    public class Element:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.KwFunction)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.Id)
                {
                    parser.NextToken();
                    if (parser.CurrenToken.Type == TokenType.PmLeftParent)
                    {
                        parser.NextToken();
                        new ParameterListOpt().Process(parser);
                        if (parser.CurrenToken.Type == TokenType.PmRightParent)
                        {
                            parser.NextToken();
                            new CompoundStatement().Process(parser);
                        }
                        else
                        {
                            throw new ParserException("This was expected )");
                        }
                    }
                    else
                    {
                        throw new ParserException("This was expected (");
                    }
                }
                else
                {
                    throw new ParserException("This was expected a Identifier");
                }
            }
            else
            {
                new Statement().Process(parser);
            }
        }
    }
}
