using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression.Operators.RelationalOperators;

namespace scriptea.Parsing.Operators
{
    public class RelationalOperator:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpGreaterThan)
            {
                parser.NextToken();
                return new GreaterThanOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpLessThan)
            {
                parser.NextToken();
                return new LessThanOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpGreaterEqualThan)
            {
                parser.NextToken();
                return new GreaterEqualThanOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpLessEqualThan)
            {
                parser.NextToken();
                return new LessEqualThanOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpEqual)
            {
                parser.NextToken();
                return new EqualOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpEquiv)
            {
                parser.NextToken();
                return new EquivOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpNotEquiv)
            {
                parser.NextToken();
                return new NotEquivOperatorNode();
            } 
            else if (parser.CurrenToken.Type == TokenType.OpNotEqual)
            {
                parser.NextToken();
                return new NotEqualOperatorNode();
            }
            else
            {
                throw new ParserException("This was expected *,/ or %, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
        }
    }
}