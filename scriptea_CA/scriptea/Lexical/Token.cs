using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Lexical
{
    public enum TokenType
    {
        Eof,
        Id,
/* LITERALS */
        LitInteger,
        LitFloat,
        LitString,
        LitBool,
/* OPERATORS */
        OpSum,
        OpSub,
        OpMul,
        OpDiv,
        OpMod,
        OpInc,
        OpDec,
        OpAssig,
        OpAssigSum,
        OpAssigSub,
        OpAssigMul,
        OpAssigDiv,
        OpAssigMod,
        OpAssigLeftShift,
        OpAssigRightShift,
        OpAssigRightShiftZeroFill,
        OpAssigBitwiseAnd,
        OpAssigBitwiseOr,
        OpAssigBitwiseXOr,
        OpEquiv,
        OpEqual,
        OpNotEquiv,
        OpNotEqual,
        OpGreaterThan,
        OpLessThan,
        OpGreaterEqualThan,
        OpLessEqualThan,
        OpAnd,
        OpOr,
        OpNot,
        OpNotBit,
        OpLeftShift,
        OpRightShift,
        OpRightShiftZeroFill,
        OpBitwiseAnd,
        OpBitwiseOr,
        OpBitwiseNot,
        OpBitwiseXOr,
        OpTernary,
/* KEYWORDS */
        KwIf,
        KwWhile,
        KwDo,
        KwFor,
        KwFunction,
        KwVar,
        KwBreak,
        KwSwitch,
        KwCase,
        KwCatch,
        KwContinue,
        KwDefault,
        KwElse,
        KwNew,
        KwReturn,
        KwThrow,
        KwTry,
        KwNull,
        KwUndefined,
        KwFinally,
/* PUNCTUATION MARKS */
        PmLeftCurlyBracket,
        PmRightCurlyBracket,
        PmLeftParent,
        PmRightParent,
        PmLeftBracket,
        PmRightBracket,
        PmSemicolon,
        PmDot,
        PmColon,
        PmComma
    }
    public class Token
    {
        public TokenType Type { get; set; }
        public string LexemeVal { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool In(TokenType[] ptypeList)
        {
            return ptypeList.Contains(Type);
        }
    }
}
