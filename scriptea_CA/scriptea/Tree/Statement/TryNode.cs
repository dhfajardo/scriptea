﻿using scriptea.Tree.Expression;

namespace scriptea.Tree.Statement
{
    public class TryNode:ExpressionNode
    {
        public ExpressionNode CompoundStatementNode { get; set; }
        public ExpressionNode CatchBlockNode { get; set; }
        public ExpressionNode FinallyNode { get; set; }
    }
}