using System.Collections.Generic;
using scriptea.Tree.Statement;

namespace scriptea.Tree.Expression
{
    public class FunctionNode:ExpressionNode
    {
        public string Name { get; set; }
        //public IdNode Id { get; set;}
        public Accesor Accesor { get; set; }
        //public List<IdNode> ParameterList { get; set; }
        //public List<StatementNode> Statements { get; set; }
        public override dynamic Evaluate()
        {
            throw new System.NotImplementedException();
        }
    }
}