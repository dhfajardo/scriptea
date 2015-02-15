using scriptea.Lexical;
using scriptea.Parsing.Expressions;
using scriptea.Parsing.Statements.Blocks;
using scriptea.Parsing.Statements.Clause;
using scriptea.Parsing.Statements.Elements;
using scriptea.Parsing.Variables;

namespace scriptea.Parsing.Statements
{
    public class Statement:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.PmSemicolon)
            {
                parser.NextToken();
            }
            else if (parser.CurrenToken.Type == TokenType.KwIf)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.PmLeftParent)
                {
                    parser.NextToken();
                    new AssignmentExpression().Process(parser);
                    if (parser.CurrenToken.Type == TokenType.PmRightParent)
                    {
                        parser.NextToken();
                        new Statementp().Process(parser);
                        new IfNot().Process(parser);
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
            else if (parser.CurrenToken.Type == TokenType.KwWhile)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.PmLeftParent)
                {
                    parser.NextToken();
                    new AssignmentExpression().Process(parser);
                    if (parser.CurrenToken.Type == TokenType.PmRightParent)
                    {
                        parser.NextToken();
                        new Statementp().Process(parser);
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
            else if (parser.CurrenToken.Type == TokenType.KwBreak)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                {
                    parser.NextToken();
                }
                else
                {
                    throw new ParserException("This was expected ;");
                }
            }
            else if (parser.CurrenToken.Type == TokenType.KwContinue)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                {
                    parser.NextToken();
                }
                else
                {
                    throw new ParserException("This was expected ;");
                }
            }
            else if (parser.CurrenToken.Type == TokenType.KwThrow)
            {
                new ThrowStatement().Process(parser);
                if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                {
                    parser.NextToken();
                }
                else
                {
                    throw new ParserException("This was expected ;");
                }
            }
            else if (parser.CurrenToken.Type == TokenType.KwSwitch)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.PmLeftParent)
                {
                    parser.NextToken();
                    new AssignmentExpression().Process(parser);
                    if (parser.CurrenToken.Type == TokenType.PmRightParent)
                    {
                        parser.NextToken();
                        if (parser.CurrenToken.Type == TokenType.PmLeftCurlyBracket)
                        {
                            parser.NextToken();
                            new CaseBlock().Process(parser);
                            if (parser.CurrenToken.Type == TokenType.PmRightCurlyBracket)
                            {
                                parser.NextToken();
                            }
                            else
                            {
                                throw new ParserException("This was expected }");
                            }
                        }
                        else
                        {
                            throw new ParserException("This was expected {");
                        }
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
            else if (parser.CurrenToken.Type == TokenType.KwDo)
            {
                parser.NextToken();
                new Statementp().Process(parser);
                if (parser.CurrenToken.Type == TokenType.KwWhile)
                {
                    parser.NextToken();
                    if (parser.CurrenToken.Type == TokenType.PmLeftParent)
                    {
                        parser.NextToken();
                        new AssignmentExpression().Process(parser);
                        if (parser.CurrenToken.Type == TokenType.PmRightParent)
                        {
                            parser.NextToken();
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
                    throw new ParserException("This was expected the token: while");
                }
            }
            else if (parser.CurrenToken.Type == TokenType.KwReturn)
            {
                parser.NextToken();
                new ExpressionOpt().Process(parser);
                if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                {
                    parser.NextToken();
                }
                else
                {
                    throw new ParserException("This was expected ;");
                }
            }
            else if (parser.CurrenToken.Type == TokenType.KwTry)
            {
                parser.NextToken();
                new CompoundStatement().Process(parser);
                new CatchBlock().Process(parser);
                new FinallyBlock().Process(parser);
            }
            else
            {
                new VariablesOrExpression().Process(parser);
                if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                {
                    parser.NextToken();
                }
                else
                {
                    throw new ParserException("This was expected ;");
                }
            }
        }
    }
}
