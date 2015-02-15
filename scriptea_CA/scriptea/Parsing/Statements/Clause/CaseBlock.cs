using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Parsing.Statements.Clause
{
    public class CaseBlock:INTerminal
    {
        public void Process(Parser parser)
        {
            new CaseClauseList().Process(parser);
            new DefauldClause().Process(parser);
        }
    }
}
