using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Operator
{
    public class UnaryOperatorNode:ExpressionNode
    {
        private static SortedDictionary<string, TokenType> _assigOp = new SortedDictionary<string, TokenType>
        {
            {"!",TokenType.OpNot}
            ,{"~",TokenType.OpNotBit}
            ,{"-",TokenType.OpSub}

        };
        public string LexematicValue { get; set; }
        public TokenType Type { get { return _assigOp[LexematicValue]; } }

        public ExpressionNode ValueExpressionNode { get; set; }

    }
}