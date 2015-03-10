using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using scriptea.Lexical;
using scriptea.Lexical.Input;
using scriptea.Parsing;
using scriptea.Parsing.Expressions;
using scriptea.Tree.Statement;

namespace scriptea.test
{
    [TestClass]
    public class TestFromFile
    {
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestProgram()
        {
            InputStream _input = new InputStream(System.IO.File.ReadAllText(@"C:\scriptea\Test\Parser\Fibonacci.txt"));
            var parser = new Parser(new Lexer(_input));
            parser.StartINTerminal = new Program();
            var _result = (List<StatementNode>)parser.Parse();
            var _resultProgram = new ProgramElement {_program = _result};
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_resultProgram);  
        }
         /*
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestProgram2()
        {
            InputStream _input = new InputStream(System.IO.File.ReadAllText(@"C:\scriptea\Test\Parser\program3.txt"));
            var parser = new Parser(new Lexer(_input));
            parser.StartINTerminal = new Program();
            parser.Parse();

        }*/
    }
}