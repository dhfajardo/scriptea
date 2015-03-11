using System.Collections.Generic;
using System.IO;
using System.Management.Instrumentation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using scriptea.Lexical;
using scriptea.Lexical.Input;
using scriptea.Parsing;
using scriptea.Parsing.Expressions;
using scriptea.Parsing.Statements;
using scriptea.Tree.Expression;
using scriptea.Tree.Statement;
using JsonSerializer = RestSharp.Serializers.JsonSerializer;

namespace scriptea.test
{
    [TestClass]
    public class TreeTesting
    {
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TreeTestExpression()
        {
            //var parser = new Parser(new Lexer(new InputStream("a.codigo[1].sumar(1,3)=-1")));
            //var parser = new Parser(new Lexer(new InputStream("a = suma(1,3)")));
            var parser = new Parser(new Lexer(new InputStream("a.id = suma(1,3)")));
            parser.StartINTerminal = new Expression();
            var _result = (List<ExpressionNode>) parser.Parse();
            var x = new RestSharp.Serializers.XmlSerializer();
            var s= x.Serialize(new AssigStatementNode(){AssignmentExpressionNode = _result});

        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TreeProgram()
        {
            var parser = new Parser(new Lexer(new InputStream("function suma(left,right) {var _left,_right; _left = left; _right = right; return _left + _right;}")));
            //var parser = new Parser(new Lexer(new InputStream("function suma() {}")));
            //var parser = new Parser(new Lexer(new InputStream("function suma(left,right) {var _left,_right;}")));
            parser.StartINTerminal = new Program();
            var _result = (List<StatementNode>)parser.Parse();
            string _resultJson = JsonConvert.SerializeObject(_result);
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TreeIntegerLiteral()
        {
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\IntegerLiteral.txt");
            var parser = new Parser(new Lexer(new InputStream("12345")));
            parser.StartINTerminal = new PrimaryExpression();
            var _result = (ExpressionNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            Assert.AreEqual(_input,_resultSerial);
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TreeBooleanLiteral()
        {
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\BooleanLiteral.txt");
            var parser = new Parser(new Lexer(new InputStream("true")));
            parser.StartINTerminal = new PrimaryExpression();
            var _result = (ExpressionNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TreeStringLiteral()
        {
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StringLiteral.txt");
            var parser = new Parser(new Lexer(new InputStream("\"String\"")));
            parser.StartINTerminal = new PrimaryExpression();
            var _result = (ExpressionNode) parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            Assert.AreEqual(_input, _resultSerial);
        }
        [TestMethod]
        public void TreeFloatLiteral()
        {
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\NullLiteral.txt");
            var parser = new Parser(new Lexer(new InputStream("null")));
            parser.StartINTerminal = new PrimaryExpression();
            var _result = (ExpressionNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementSum()
        {
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementSum.txt");
            var parser = new Parser(new Lexer(new InputStream("id1+id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            Assert.AreEqual(_input, _resultSerial);
        }
        [TestMethod]
        public void TreeStatementSub()
        {
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementSub.txt");
            var parser = new Parser(new Lexer(new InputStream("id1-id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementMul()
        {
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementMul.txt");
            var parser = new Parser(new Lexer(new InputStream("id1*id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementDiv()
        {
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementDiv.txt");
            var parser = new Parser(new Lexer(new InputStream("id1/id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementAssig()
        {
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementAssig.txt");
            var parser = new Parser(new Lexer(new InputStream("id1=id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementAssigMul()
        {
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementAssigMul.txt");
            var parser = new Parser(new Lexer(new InputStream("id1*=id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementAssigDiv()
        {
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementAssigDiv.txt");
            var parser = new Parser(new Lexer(new InputStream("id1/=id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementAssigMod()
        {
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementAssigMod.txt");
            var parser = new Parser(new Lexer(new InputStream("id1%=id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementAssigSum()
        {
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementAssigSum.txt");
            var parser = new Parser(new Lexer(new InputStream("id1+=id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementAssigSub()
        {
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementAssigSub.txt");
            var parser = new Parser(new Lexer(new InputStream("id1-=id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementAssigLeftShift()
        {
            var parser = new Parser(new Lexer(new InputStream("id1<<=id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementAssigLeftShift.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementAssigRightShift()
        {
            var parser = new Parser(new Lexer(new InputStream("id1>>=id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementAssigRightShift.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementAssigRightShiftZeroFill()
        {
            var parser = new Parser(new Lexer(new InputStream("id1>>>=id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementAssigRightShiftZeroFill.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementAssigBitwiseAnd()
        {
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementAssigBitwizeAnd.txt");
            var parser = new Parser(new Lexer(new InputStream("id1&=id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementAssigBitwiseOr()
        {
            var parser = new Parser(new Lexer(new InputStream("id1^=id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementAssigBitwiseOr.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementAssigBitwiseXOr()
        {
            var parser = new Parser(new Lexer(new InputStream("id1|=id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementAssigBitwiseXOr.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementGreaterThan()
        {
            var parser = new Parser(new Lexer(new InputStream("id1>id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementGreaterThan.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementLessThan()
        {
            var parser = new Parser(new Lexer(new InputStream("id1<id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementLessThan.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementGreaterEqualThan()
        {
            var parser = new Parser(new Lexer(new InputStream("id1>=id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementGreaterEqualThan.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementLessEqualThan()
        {
            var parser = new Parser(new Lexer(new InputStream("id1<=id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementLessEqualThan.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementEqual()
        {
            var parser = new Parser(new Lexer(new InputStream("id1>id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementEqual.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementEquiv()
        {
            var parser = new Parser(new Lexer(new InputStream("id1==id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementEquiv.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementNotEqual()
        {
            var parser = new Parser(new Lexer(new InputStream("id1!==id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementNotEqual.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementNotEquiv()
        {
            var parser = new Parser(new Lexer(new InputStream("id1!=id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementNotEquiv.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementLeftShift()
        {
            var parser = new Parser(new Lexer(new InputStream("id1<<id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementLeftShift.txt");
            Assert.AreEqual(_input, _resultSerial);
        }
        [TestMethod]
        public void TreeStatementRightShift()
        {
            var parser = new Parser(new Lexer(new InputStream("id1>>id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementRightShift.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementRightShiftZeroFill()
        {
            var parser = new Parser(new Lexer(new InputStream("id1!=id2;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementRightShiftZeroFill.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementNot()
        {
            var parser = new Parser(new Lexer(new InputStream("!id;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementNot.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementNotBit()
        {
            var parser = new Parser(new Lexer(new InputStream("~id;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementNotBit.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementNegative()
        {
            var parser = new Parser(new Lexer(new InputStream("-id;")));
            parser.StartINTerminal = new Statement();
            var _result = (AssigStatementNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementNegative.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementSuma()
        {
            var parser = new Parser(new Lexer(new InputStream("2+\"hola\"")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            Assert.AreEqual("2hola", _result.Evaluate());
        }

        [TestMethod]
        public void TreeStatementNew()
        {
            var parser = new Parser(new Lexer(new InputStream("a = new system.io.suma(1,2)")));
            parser.StartINTerminal = new Expression();
            var _result = parser.Parse();
        }
    }
}