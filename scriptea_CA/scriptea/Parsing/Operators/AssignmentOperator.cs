using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression.Operators.AssignmentOperators;

namespace scriptea.Parsing.Operators
{
    public class AssignmentOperator:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpAssig)
            {
                parser.NextToken();
                return new AssigOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigDiv)
            {
                parser.NextToken();
                return new AssigDivOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigMul)
            {
                parser.NextToken();
                return new AssigMulOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigMod)
            {
                parser.NextToken();
                return new AssigModOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigSum)
            {
                parser.NextToken();
                return new AssigSumOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigSub)
            {
                parser.NextToken();
                return new AssigSubOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigLeftShift)
            {
                parser.NextToken();
                return new AssigLeftShiftOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigRightShift)
            {
                parser.NextToken();
                return new AssigRightShiftOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigRightShiftZeroFill)
            {
                parser.NextToken();
                return new AssigRightZeroFillShiftOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigBitwiseAnd)
            {
                parser.NextToken();
                return new AssigBitwiseAndOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigBitwiseOr)
            {
                parser.NextToken();
                return new AssigBitwiseOrOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpAssigBitwiseXOr)
            {
                parser.NextToken();
                return new AssigBitwiseXOrOperatorNode();
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