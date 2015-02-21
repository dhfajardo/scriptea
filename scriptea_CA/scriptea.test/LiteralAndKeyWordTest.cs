using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using scriptea.Lexical;
using scriptea.Lexical.Input;
using scriptea.Parsing;
using scriptea.Parsing.Literals;
using scriptea.Parsing.Operators;

namespace scriptea.test
{
    [TestClass]
    public class LiteralAndKeyWordTest
    {
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestBooleanLiteralAndKeyWords()
        {
                SortedDictionary<string, TokenType> _keyWords = new SortedDictionary<string, TokenType>
                {
                    {"true",TokenType.LitBool},
                    {"false",TokenType.LitBool}

                };
            foreach (var tokenType in _keyWords)
            {
                var parser = new Parser(new Lexer(new InputStream(tokenType.Key)));
                parser.StartINTerminal = new BooleanLiteral();
                parser.Parse();
            }
        }


    }
}