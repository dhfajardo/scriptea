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
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.PmDot)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.Id)
                {
                    parser.NextToken();
                    this.Process(parser, parameters);
                }
                else
                {
                    throw new ParserException("This was expected a Identifier, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else if (parser.CurrenToken.Type == TokenType.PmLeftBracket)
            {
                parser.NextToken();
                new AssignmentExpression().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.PmRightBracket)
                {
                    parser.NextToken();
                    this.Process(parser, parameters);
                }
                else
                {
                    throw new ParserException("This was expected ], Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else if (parser.CurrenToken.Type == TokenType.PmLeftParent)
            {
                parser.NextToken();
                new ExpressionOpt().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.PmRightParent)
                {
                    parser.NextToken();
                    this.Process(parser, parameters);
                }
                else
                {
                    throw new ParserException("This was expected ), Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else
            {
                //Epsilon
                //throw new ParserException("This was expected [, ( or .");
            }
            return null;
        }
    }
}
