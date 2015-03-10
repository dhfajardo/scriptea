using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Parameters
{
    public class ParameterList:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                string _idName = parser.CurrenToken.LexemeVal;
                parser.NextToken();
                var _singleId = new IdNode {Name = _idName};
                List<IdNode> _listIds;
                _listIds = (List<IdNode>) new ParameterListp().Process(parser, parameters);
                _listIds.Insert(0, _singleId);
                return _listIds;
            }
            else
            {
                throw new ParserException("This was expected a Identifier in the parameter, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
        }
    }
}