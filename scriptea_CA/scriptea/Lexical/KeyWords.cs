using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Lexical
{
    public class KeyWords
    {
        private static SortedDictionary<string, TokenType> _keyWords = new SortedDictionary<string, TokenType>
        {
            {"if",TokenType.KwIf},
            {"while",TokenType.KwWhile},
            {"do",TokenType.KwDo},
            {"for",TokenType.KwFor},
            {"function",TokenType.KwFunction},
            {"var",TokenType.KwVar},
            {"break",TokenType.KwBreak},
            {"switch",TokenType.KwSwitch},
            {"case",TokenType.KwCase},
            {"catch",TokenType.KwCatch},
            {"continue",TokenType.KwContinue},
            {"default",TokenType.KwDefault},
            {"else",TokenType.KwElse},
            {"new",TokenType.KwNew},
            {"return",TokenType.KwReturn},
            {"throw",TokenType.KwThrow},
            {"try",TokenType.KwTry},
            {"null",TokenType.KwNull},
            {"undefined",TokenType.KwNull},
            {"true",TokenType.LitBool},
            {"false",TokenType.LitBool},
            {"finally",TokenType.KwFinally}

        };
        public static bool Contains(string pSymbol)
        {
            return _keyWords.ContainsKey(pSymbol);
        }
        public static TokenType GetTokenType(string pSymbol)
        {
            return _keyWords[pSymbol];
        }
    }
}
