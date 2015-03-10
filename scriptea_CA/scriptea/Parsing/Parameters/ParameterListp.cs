using System.Collections.Generic;
using System.Configuration;
using scriptea.Lexical;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Parameters
{
    public class ParameterListp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.PmComma)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.Id)
                {
                    string _idName = parser.CurrenToken.LexemeVal;
                    var _singleId = new IdNode{Name = _idName};
                    List<IdNode> _idList;
                    parser.NextToken();
                    _idList =(List<IdNode>) this.Process(parser, parameters);
                    _idList.Insert(0,_singleId);
                    return _idList;
                }
                else
                {
                    throw new ParserException("This was expected a Identifier in the parameter, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else
            {
                return new List<IdNode>();
            }
        }
    }
}
