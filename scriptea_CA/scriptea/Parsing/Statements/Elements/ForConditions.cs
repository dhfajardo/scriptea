using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Expressions;
using scriptea.Parsing.Variables;

namespace scriptea.Parsing.Statements.Elements
{
    public class ForConditions:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwVar)
            {
                parser.NextToken();
                new VariableList().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                {
                    parser.NextToken();
                    new ExpressionOpt().Process(parser, parameters);
                    if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                    {
                        parser.NextToken();
                        new ExpressionOpt().Process(parser, parameters);
                    }
                    else
                    {
                        throw new ParserException("This was expected ;");
                    }
                }
                else
                {
                    throw new ParserException("This was expected ;");
                }
            }
            else
            {
                new ExpressionOpt().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                {
                    parser.NextToken();
                    new ExpressionOpt().Process(parser, parameters);
                    if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                    {
                        parser.NextToken();
                        new ExpressionOpt().Process(parser, parameters);
                    }
                    else
                    {
                        throw new ParserException("This was expected ;");
                    }
                }
                else
                {
                    throw new ParserException("This was expected ;");
                }
            }
            return null;
        }
    }
}
