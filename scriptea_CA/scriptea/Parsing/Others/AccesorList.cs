using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;
using scriptea.Parsing.Expressions;

namespace scriptea.Parsing.Others
{
    public  class AccesorList:INTerminal 
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.PmDot)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.Id)
                {
                    parser.NextToken();
                    this.Process(parser);
                }
                else
                {
                    throw  new ParserException("This was expected a Identifier");
                }
            }
            else if (parser.CurrenToken.Type == TokenType.PmLeftBracket)
            {
                parser.NextToken();
                new AssignmentExpression().Process(parser);
                if (parser.CurrenToken.Type == TokenType.PmRightBracket)
                {
                    parser.NextToken();
                    this.Process(parser);
                }
                else
                {
                    throw new ParserException("This was expected ]");
                }
            }
            else if (parser.CurrenToken.Type == TokenType.PmLeftParent)
            {
                parser.NextToken();
                new ExpressionOpt().Process(parser);
                if (parser.CurrenToken.Type == TokenType.PmRightParent)
                {
                    parser.NextToken();
                    this.Process(parser);
                }
                else
                {
                    throw new ParserException("This was expected )");
                }
            }
            else
            {
                throw new ParserException("This was expected [, ( or .");
            }
        }
    }
}
