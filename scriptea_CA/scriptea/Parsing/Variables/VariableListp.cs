using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Expressions;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Variables
{
    public class VariableListp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.PmComma)
            {
                parser.NextToken();
                var _single = (ExpressionNode) new Variable().Process(parser, parameters);
                List<ExpressionNode> _listEp;
                _listEp = (List<ExpressionNode>) this.Process(parser, parameters);
                _listEp.Insert(0,_single);
                return _listEp;
            }
            else
            {
                return new List<ExpressionNode>();
            }
        }
    }
}