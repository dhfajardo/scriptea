using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Tree.Statement
{
    public abstract class StatementNode
    {
        public StatementNode Next { get; set; }
        public abstract void Interpret(SymbolTable table);
    }
}
