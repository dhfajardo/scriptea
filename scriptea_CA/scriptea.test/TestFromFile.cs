using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using scriptea.Lexical;
using scriptea.Lexical.Input;
using scriptea.Parsing;
using scriptea.Parsing.Expressions;

namespace scriptea.test
{
    [TestClass]
    public class TestFromFile
    {
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestProgram()
        {
            InputStream _input = new InputStream(System.IO.File.ReadAllText(@"C:\Users\hnfajardoa\Documents\GitHub\scriptea\Test\Parser\prgTest.txt"));
            var parser = new Parser(new Lexer(_input));
            parser.StartINTerminal = new Program();
            parser.Parse();
            
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestProgram2()
        {
            InputStream _input = new InputStream(System.IO.File.ReadAllText(@"C:\Users\hnfajardoa\Documents\GitHub\scriptea\Test\Parser\program3.txt"));
            var parser = new Parser(new Lexer(_input));
            parser.StartINTerminal = new Program();
            parser.Parse();

        }
    }
}