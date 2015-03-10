using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Statement;

namespace scriptea.Parsing.Statements.Elements
{
    public class IfNot:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwElse)
            {
                parser.NextToken();
                var _elseCode = (List<StatementNode>) new Statementp().Process(parser, parameters);
                return new ElseNode {CodeNode = _elseCode};
            }
            else
            {
                return new ElseNode();
            }
        }
    }
}
