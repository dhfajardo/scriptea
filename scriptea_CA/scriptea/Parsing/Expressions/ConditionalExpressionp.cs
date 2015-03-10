using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Operators;

namespace scriptea.Parsing.Expressions
{
    public class ConditionalExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (ExpressionNode) parameters["LeftNode"];
            if (parser.CurrenToken.Type == TokenType.OpTernary)
            {
                parser.NextToken();
                var _trueEp = (ExpressionNode) new AssignmentExpression().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.PmColon)
                {
                    parser.NextToken();
                    var _falseEp = (ExpressionNode) new AssignmentExpression().Process(parser, parameters);
                    var _result = new TernaryNode
                    {
                        EvaluationExpression = _leftNode,
                        TrueExpression = _trueEp,
                        FalseExpression = _falseEp
                    };
                    return _result;
                }
                else
                {
                    throw new ParserException("This was expected : in the conditional expression, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else
            {
                return _leftNode;
            }
        }
    }
}