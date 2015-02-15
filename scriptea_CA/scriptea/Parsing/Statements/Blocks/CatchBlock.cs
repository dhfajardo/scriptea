using scriptea.Lexical;

namespace scriptea.Parsing.Statements.Blocks
{
    public class CatchBlock:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.KwCatch)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.PmLeftParent)
                {
                    parser.NextToken();
                    if (parser.CurrenToken.Type == TokenType.Id)
                    {
                        parser.NextToken();
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
                        throw  new ParserException("This was expected a Identifier");
                    }
                }
                else
                {
                    throw new ParserException("This was expected (");
                }
            }
            else
            {
                //Epsilon
            }
        }
    }
}
