using scriptea.Lexical;
using scriptea.Parsing.Expressions;
using scriptea.Parsing.Variables;

namespace scriptea.Parsing.Statements.Elements
{
    public class ForConditions:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.KwVar)
            {
                parser.NextToken();
                new VariableList().Process(parser);
                if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                {
                    parser.NextToken();
                    new ExpressionOpt().Process(parser);
                    if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                    {
                        parser.NextToken();
                        new ExpressionOpt().Process(parser);
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
                new ExpressionOpt().Process(parser);
                if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                {
                    parser.NextToken();
                    new ExpressionOpt().Process(parser);
                    if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                    {
                        parser.NextToken();
                        new ExpressionOpt().Process(parser);
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
        }
    }
}
