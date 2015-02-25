using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Tree.Expression
{
    public class IdNode:ExpressionNode
    {
        public string Name { get; set; }
        public Accesor Accesor { get; set; }
    }
}
