using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Expressions
{
    public class Expressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.PmComma)
            {
                parser.NextToken();
                var _singleAssig = (ExpressionNode) new AssignmentExpression().Process(parser, parameters);
                List<ExpressionNode> _listEp;
                _listEp = (List<ExpressionNode>) this.Process(parser, parameters);
                _listEp.Insert(0,_singleAssig);
                return _listEp;
            }
            else
            {
                return new List<ExpressionNode>();
            }
        }
    }
}