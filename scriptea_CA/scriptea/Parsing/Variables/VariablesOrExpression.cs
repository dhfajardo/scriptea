using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Expressions;
using scriptea.Tree.Expression;
using scriptea.Tree.Statement;

namespace scriptea.Parsing.Variables
{
    public class VariablesOrExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {

            if (parser.CurrenToken.Type == TokenType.KwVar)
            {
                parser.NextToken();
                List<ExpressionNode> _listEp = (List<ExpressionNode>) new VariableList().Process(parser, parameters);
                return new AssigStatementNode {AssignmentExpressionNode = _listEp};
            }
            else
            {
                List<ExpressionNode> _listEp = (List<ExpressionNode>) new Expression().Process(parser, parameters);
                return new AssigStatementNode {AssignmentExpressionNode = _listEp};
            }
        }
    }
}