using System.Collections.Generic;

namespace scriptea.Tree.Expression
{
    public abstract class Accesor
    {
        public Accesor NextAccesor { get; set; }
    }

    public class FunctionAccesor : Accesor
    {
        public string Name { get; set; }
        public List<ExpressionNode> ParameterList { get; set; } 
    }

    public class FieldAccesor : Accesor
    {
        public string Name { get; set; }
    }

    public class IndexAcessor : Accesor
    {
        public ExpressionNode IndexList { get; set; } 
    }
}