using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using scriptea.Tree.Others;

namespace scriptea.Parsing.Statements.Clause
{
    public class CaseBlock:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _case = (CaseNode)new CaseClauseList().Process(parser, parameters);
            var _defauld = (BaseCaseNode)new DefauldClause().Process(parser, parameters);
            //_case.NextCase = _defauld;
            if (_case.CodeNode == null)
            {
                return _defauld;
            }
            else
            {
                if (_defauld.CodeNode != null)
                {
                    SetListCase(_case.NextCase, _defauld);
                }
                return _case;
            }
        }

        public void SetListCase(BaseCaseNode _caseNode, BaseCaseNode _baseCaseNode)
        {
            if (_caseNode.NextCase == null)
            {
                _caseNode.NextCase = _baseCaseNode;
            }
            else
            {
                SetListCase(_caseNode.NextCase,_baseCaseNode);
            }
        }
    }
}
