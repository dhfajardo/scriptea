﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Tree.Expression.Operators
{
    public class TernaryNode
    {
        public ExpressionNode EvaluationExpression { get; set; }
        public ExpressionNode TrueExpression { get; set; }
        public ExpressionNode FalseExpression { get; set; }
    }
}