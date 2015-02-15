using scriptea.Lexical;
using scriptea.Parsing.Operators;

namespace scriptea.Parsing.Expressions
{
    public class RelationalExpressionp:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.OpGreaterThan
                || parser.CurrenToken.Type == TokenType.OpGreaterEqualThan
                || parser.CurrenToken.Type == TokenType.OpLessThan
                || parser.CurrenToken.Type == TokenType.OpLessEqualThan)
            {
                new RelationalOperator().Process(parser);
                new ShiftExpression().Process(parser);
                this.Process(parser);
            }
            else
            {
                //Epsilon
            }
        }
    }
}