﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Tree.Expression.Operators
{
    public class TernaryNode:ExpressionNode
    {
        public ExpressionNode EvaluationExpression { get; set; }
        public ExpressionNode TrueExpression { get; set; }
        public ExpressionNode FalseExpression { get; set; }
        public override dynamic Evaluate(SymbolTable table)
        {
            if (EvaluationExpression.Evaluate(table))
            {
                return TrueExpression.Evaluate(table);
            }
            else
            {
                return FalseExpression.Evaluate(table);
            }
        }
    }
}
