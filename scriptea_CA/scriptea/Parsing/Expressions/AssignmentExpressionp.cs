using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Operators;

namespace scriptea.Parsing.Expressions
{
    public class AssignmentExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpAssig
                || parser.CurrenToken.Type == TokenType.OpAssigMul
                || parser.CurrenToken.Type == TokenType.OpAssigDiv
                || parser.CurrenToken.Type == TokenType.OpAssigMod
                || parser.CurrenToken.Type == TokenType.OpAssigSum
                || parser.CurrenToken.Type == TokenType.OpAssigSub
                || parser.CurrenToken.Type == TokenType.OpAssigLeftShift
                || parser.CurrenToken.Type == TokenType.OpAssigRightShift
                || parser.CurrenToken.Type == TokenType.OpAssigRightShiftZeroFill
                || parser.CurrenToken.Type == TokenType.OpAssigBitwiseAnd
                || parser.CurrenToken.Type == TokenType.OpAssigBitwiseOr
                || parser.CurrenToken.Type == TokenType.OpAssigBitwiseXOr)
            {
                new AssignmentOperator().Process(parser, parameters);
                new ConditionalExpression().Process(parser, parameters);
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