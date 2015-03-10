using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Expressions
{
    public class Expression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            List<ExpressionNode> _listEp;
            var _singleAssig = (ExpressionNode) new AssignmentExpression().Process(parser, parameters);
            _listEp =(List<ExpressionNode>) new Expressionp().Process(parser, parameters);
            _listEp.Insert(0,_singleAssig);
            return _listEp;
        }
    }
}