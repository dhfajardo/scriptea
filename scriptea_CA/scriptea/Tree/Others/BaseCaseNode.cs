using System.Collections.Generic;
using scriptea.Tree.Expression;
using scriptea.Tree.Statement;

namespace scriptea.Tree.Others
{
    public class BaseCaseNode
    {
        public List<StatementNode> CodeNode { get; set; }
        public BaseCaseNode /*CaseNode*/ NextCase { get; set; }
    }
}