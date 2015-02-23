using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Parsing.Statements.Clause
{
    public class CaseBlock:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            new CaseClauseList().Process(parser, parameters);
            new DefauldClause().Process(parser, parameters);
            return null;
        }
    }
}
