using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Lexical
{
    public class PunctuationMarks
    {
        private static SortedDictionary<char, TokenType> _PuncMarks = new SortedDictionary<char, TokenType>
        {
            {')',TokenType.PmRightParent},
            {'(',TokenType.PmLeftParent},
            {'[',TokenType.PmLeftBracket},
            {']',TokenType.PmRightBracket},
            {'{',TokenType.PmLeftCurlyBracket},
            {'}',TokenType.PmRightCurlyBracket},
            {'.',TokenType.PmDot},
            {',',TokenType.PmComma},
            {':',TokenType.PmColon},
            {';',TokenType.PmSemicolon}
        };
        public static bool Contains(char pSymbol)
        {
            return _PuncMarks.ContainsKey(pSymbol);
        }
        public static TokenType GetTokenType(char pSymbol)
        {
            return _PuncMarks[pSymbol];
        }
    }
}
