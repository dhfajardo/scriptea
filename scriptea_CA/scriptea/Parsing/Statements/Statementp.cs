using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression;
using scriptea.Tree.Statement;

namespace scriptea.Parsing.Statements
{
    public class Statementp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.PmLeftCurlyBracket)
            {
                return new CompoundStatement().Process(parser, parameters);
            }
            else
            {
                var _singleStatement = (StatementNode) new Statement().Process(parser, parameters);
                var _statementList = new List<StatementNode>();
                _statementList.Insert(0,_singleStatement);
                return _statementList;
            }
        }
    }
}
