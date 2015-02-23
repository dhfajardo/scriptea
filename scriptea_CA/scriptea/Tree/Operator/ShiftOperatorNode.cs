using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Operator
{
    public class ShiftOperatorNode:ExpressionNode
    {
        private static SortedDictionary<string, TokenType> _assigOp = new SortedDictionary<string, TokenType>
        {
            {">>",TokenType.OpRightShift}
            ,{"<<",TokenType.OpLeftShift}
            ,{">>>",TokenType.OpRightShiftZeroFill}
        };
        public string LexematicValue { get; set; }
        public TokenType Type { get { return _assigOp[LexematicValue]; } }

        public ExpressionNode LeftNode { get; set; }
        public ExpressionNode RightNode { get; set; }

    }
}