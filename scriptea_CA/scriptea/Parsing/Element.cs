using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Parameters;
using scriptea.Parsing.Statements;

namespace scriptea.Parsing
{
    public class Element:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
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
                        new ParameterListOpt().Process(parser, parameters);
                        if (parser.CurrenToken.Type == TokenType.PmRightParent)
                        {
                            parser.NextToken();
                            new CompoundStatement().Process(parser, parameters);
                        }
                        else
                        {
                            throw new ParserException("This was expected ) Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                        }
                    }
                    else
                    {
                        throw new ParserException("This was expected ( Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                    }
                }
                else
                {
                    throw new ParserException("This was expected a Identifier, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else
            {
                new Statement().Process(parser, parameters);
            }
            return null;
        }
    }
}
