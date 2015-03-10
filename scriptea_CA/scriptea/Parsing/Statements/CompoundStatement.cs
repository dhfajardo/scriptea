using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Statements
{
    public class CompoundStatement:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.PmLeftCurlyBracket)
            {
                parser.NextToken();
                var _statementLit = new StatementList().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.PmRightCurlyBracket)
                {
                    parser.NextToken();
                    return _statementLit;
                }
                else
                {
                    throw new ParserException("This was expected } Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else
            {
                throw new ParserException("This was expected { Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
        }
    }
}