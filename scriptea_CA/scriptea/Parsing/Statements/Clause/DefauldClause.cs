using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Others;
using scriptea.Tree.Statement;

namespace scriptea.Parsing.Statements.Clause
{
    public class DefauldClause:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwDefault)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.PmColon)
                {
                    parser.NextToken();
                    var _defauldCode = (List<StatementNode>) new StatementList().Process(parser, parameters);
                    var _defauld = new DefauldNode {CodeNode = _defauldCode};
                    _defauld.NextCase = (CaseNode) new CaseClauseList().Process(parser, parameters);
                    return _defauld;
                }
                else
                {
                    throw new ParserException("This was expected : in the defauld clause, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else
            {
                return new DefauldNode();
            }
        }
    }
}