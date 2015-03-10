using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Expressions.Constructor;
using scriptea.Tree.Expression;
using scriptea.Tree.Statement;

namespace scriptea.Parsing.Statements
{
    public class ThrowStatement:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwThrow)
            {
                parser.NextToken();
                var _statThrow = (ExpressionNode) new ThrowStatementp().Process(parser, parameters);
                var _throw = new ThrowNode {ThrowStatementNode = _statThrow};
                return _throw;
            }
            else
            {
                //Epsilon
                throw new ParserException("This was expected the token: throw, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
        }
    }
}