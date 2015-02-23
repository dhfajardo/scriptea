using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Operators;

namespace scriptea.Parsing.Expressions
{
    public class RelationalExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpGreaterThan
                || parser.CurrenToken.Type == TokenType.OpGreaterEqualThan
                || parser.CurrenToken.Type == TokenType.OpLessThan
                || parser.CurrenToken.Type == TokenType.OpLessEqualThan
                || parser.CurrenToken.Type == TokenType.OpNotEqual
                || parser.CurrenToken.Type == TokenType.OpEquiv
                || parser.CurrenToken.Type == TokenType.OpEqual)
            {
                new RelationalOperator().Process(parser, parameters);
                new ShiftExpression().Process(parser, parameters);
                this.Process(parser, parameters);
            }
            else
            {
                //Epsilon
            }
            return null;
        }
    }
}