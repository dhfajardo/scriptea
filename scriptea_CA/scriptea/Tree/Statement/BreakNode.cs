﻿using System.Runtime.InteropServices;
using scriptea.Lexical;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class BreakNode:StatementNode
    {
        public override void Interpret(SymbolTable table, FunctionTable functionTable)
        {
            throw new BreakException("");
        }
    }
}