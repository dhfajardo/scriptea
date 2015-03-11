using Microsoft.VisualStudio.TestTools.UnitTesting;
using scriptea.Lexical;
using scriptea.Lexical.Input;
using scriptea.Parsing;
using scriptea.Parsing.Statements;
using scriptea.Tree.Statement;

namespace scriptea.test
{
    [TestClass]
    public class TreeStatements
    {
        [TestMethod]
        public void TreeStatementIf()
        {
            var parser = new Parser(new Lexer(new InputStream("if(id=id2){if(id3=id4) count++;}")));
            parser.StartINTerminal = new Statement();
            var _result = (IfNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementIf.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementIfWithElse()
        {
            var parser = new Parser(new Lexer(new InputStream("if(id=id2){if(id3=id4) count++; else count--;}else{count+=2;}")));
            parser.StartINTerminal = new Statement();
            var _result = (IfNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementIfWithElse.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementWhile()
        {
            var parser = new Parser(new Lexer(new InputStream("while(\"hola\" = \"hola\"){while(true) count++;}")));
            parser.StartINTerminal = new Statement();
            var _result = (WhileNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementWhile.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementFor()
        {
            var parser = new Parser(new Lexer(new InputStream("for(var id;id<5;id++){for(id;id>=id2;id--) if(true) count++; else count--;}")));
            parser.StartINTerminal = new Statement();
            var _result = (ForNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementFor.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementBreak()
        {
            var parser = new Parser(new Lexer(new InputStream("break;")));
            parser.StartINTerminal = new Statement();
            var _result = (BreakNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementBreak.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementThrowId()
        {
            var parser = new Parser(new Lexer(new InputStream("throw id;")));
            parser.StartINTerminal = new Statement();
            var _result = (ThrowNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementThrow.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementThrowNew()
        {
            var parser = new Parser(new Lexer(new InputStream("throw new suma.id(1,true);")));
            parser.StartINTerminal = new Statement();
            var _result = (ThrowNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementThrowNew.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementSwitch()
        {
            var parser = new Parser(new Lexer(new InputStream("switch(id){case 1: count++; break; case 2: if(true) count--; /*default: count++; id = count; case 3: --count;*/}")));
            parser.StartINTerminal = new Statement();
            var _result = (SwitchNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementSwitch.txt");
            Assert.AreEqual(_input, _resultSerial);
        }


        [TestMethod]
        public void TreeStatementSwitchWithDefauld()
        {
            var parser = new Parser(new Lexer(new InputStream("switch(id){case 1: count++; break; case 2: if(true) count--; default: count++; id = count; case 3: --count;}")));
            parser.StartINTerminal = new Statement();
            var _result = (SwitchNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementSwitchWithDefauld.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementDo()
        {
            var parser = new Parser(new Lexer(new InputStream("do{count++; if(!false) ++count;}while(true)")));
            parser.StartINTerminal = new Statement();
            var _result = (DoWhileNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementDoWhile.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementReturn()
        {
            var parser = new Parser(new Lexer(new InputStream("return;")));
            parser.StartINTerminal = new Statement();
            var _result = (ReturnNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementReturn.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementReturnWithExp()
        {
            var parser = new Parser(new Lexer(new InputStream("return suma(1,false);")));
            parser.StartINTerminal = new Statement();
            var _result = (ReturnNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementReturnExp.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementTry()
        {
            var parser = new Parser(new Lexer(new InputStream("try{id = id2;}")));
            parser.StartINTerminal = new Statement();
            var _result = (TryNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementTry.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementTryCatch()
        {
            var parser = new Parser(new Lexer(new InputStream("try{id = id2;}catch(id){}")));
            parser.StartINTerminal = new Statement();
            var _result = (TryNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementTryCatch.txt");
            Assert.AreEqual(_input, _resultSerial);
        }

        [TestMethod]
        public void TreeStatementTryCatchFinally()
        {
            var parser = new Parser(new Lexer(new InputStream("try{id = id2;}catch(id){}finally{}")));
            parser.StartINTerminal = new Statement();
            var _result = (TryNode)parser.Parse();
            var _serializer = new RestSharp.Serializers.XmlSerializer();
            var _resultSerial = _serializer.Serialize(_result);
            var _input = System.IO.File.ReadAllText(@"C:\scriptea\Test\Tree\StatementTryCatchFinally.txt");
            Assert.AreEqual(_input, _resultSerial);
        }
    }
}