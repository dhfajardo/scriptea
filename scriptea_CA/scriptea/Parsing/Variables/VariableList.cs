using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Variables
{
    public class VariableList:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _single = (ExpressionNode) new Variable().Process(parser, parameters);
            List<ExpressionNode> _listEp;
            _listEp = (List<ExpressionNode>) new VariableListp().Process(parser, parameters);
            _listEp.Insert(0,_single);
            return _listEp;
        }
    }
}