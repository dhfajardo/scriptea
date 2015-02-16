using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using scriptea.Lexical;
using scriptea.Lexical.Input;
using scriptea.Parsing;
using scriptea.Parsing.Expressions;
using  scriptea.Parsing.Operators;

namespace scriptea.test
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void TestOPDec()
        {
            var parser = new Parser(new Lexer(new InputStream("--")));
            parser.StartINTerminal = new DecrementOperator();
            parser.Parse();
        }
        [TestMethod]
        public void TestOPInc()
        {
            var parser = new Parser(new Lexer(new InputStream("++")));
            parser.StartINTerminal = new IncrementOperator();
            parser.Parse();
        }
        [TestMethod]
        public void TestOpUnary()
        {
            var parser = new Parser(new Lexer(new InputStream("~")));
            parser.StartINTerminal = new UnaryOperator();
            parser.Parse();
        }
        [TestMethod]
        public void TestExPrimary()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new PrimaryExpression();
            parser.Parse();
        }
    }
}
