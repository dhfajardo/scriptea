using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Expressions;
using scriptea.Tree.Others;

namespace scriptea.Parsing.Statements.Clause
{
    public class CaseClauseList:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwCase)
            {
                var _caseList = (CaseNode) new CaseClause().Process(parser, parameters);
                //var _case = (CaseNode)this.Process(parser, parameters);
                _caseList.NextCase = (CaseNode) this.Process(parser, parameters);
                return _caseList;
            }
            else
            {
                return new CaseNode();
            }
        }
    }
}