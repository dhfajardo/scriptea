using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Operator
{
    public class AssigOperatorNode:ExpressionNode
    {
        private static SortedDictionary<string, TokenType> _assigOp = new SortedDictionary<string, TokenType>
        {
            {"=",TokenType.OpAssig}
            ,{"*=",TokenType.OpAssigMul}
            ,{"/=",TokenType.OpAssigMod}
            ,{"+=",TokenType.OpAssigSum}
            ,{"-=",TokenType.OpAssigSub}
            ,{"<<=",TokenType.OpAssigLeftShift}
            ,{">>=",TokenType.OpAssigRightShift}
            ,{">>>=",TokenType.OpAssigRightShiftZeroFill}
            ,{"&=",TokenType.OpAssigBitwiseAnd}
            ,{"^=",TokenType.OpAssigBitwiseXOr}
            ,{"|=",TokenType.OpAssigBitwiseOr}

        };
        public string LexematicValue { get; set; }
        public TokenType Type { get { return _assigOp[LexematicValue]; } }
        public ExpressionNode LeftNode { get; set; }
        public ExpressionNode RightNode { get; set; }

    }
}
