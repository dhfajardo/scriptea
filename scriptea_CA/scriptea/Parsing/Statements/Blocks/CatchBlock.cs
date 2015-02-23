using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Statements.Blocks
{
    public class CatchBlock:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
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
                            new CompoundStatement().Process(parser, parameters);
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
            return null;
        }
    }
}
