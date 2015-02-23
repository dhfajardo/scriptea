using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression;

namespace scriptea.Tree.Operator
{
    public class MultiplicativeOperatorNode:ExpressionNode
    {
        private static SortedDictionary<string, TokenType> _assigOp = new SortedDictionary<string, TokenType>
        {
            {"*",TokenType.OpMul}
            ,{"/",TokenType.OpDiv}
            ,{"%",TokenType.OpMod}

        };
        public string LexematicValue { get; set; }
        public TokenType Type { get { return _assigOp[LexematicValue]; } }

        public ExpressionNode LeftNode { get; set; }
        public ExpressionNode RightNode { get; set; }

    }
}