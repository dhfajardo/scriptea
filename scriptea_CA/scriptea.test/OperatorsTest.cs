using Microsoft.VisualStudio.TestTools.UnitTesting;
using scriptea.Lexical;
using scriptea.Lexical.Input;
using scriptea.Parsing;
using scriptea.Parsing.Expressions;
using scriptea.Parsing.Expressions.Constructor;
using scriptea.Parsing.Literals;
using scriptea.Parsing.Operators;
using scriptea.Parsing.Others;
using scriptea.Parsing.Parameters;
using scriptea.Parsing.Statements;
using scriptea.Parsing.Statements.Blocks;
using scriptea.Parsing.Statements.Clause;
using scriptea.Parsing.Statements.Elements;
using scriptea.Parsing.Variables;

namespace scriptea.test
{
    [TestClass]
    public class OperatorsTest
    {
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestOPDec()
        {
            var parser = new Parser(new Lexer(new InputStream("--")));
            parser.StartINTerminal = new DecrementOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestOPInc()
        {
            var parser = new Parser(new Lexer(new InputStream("++")));
            parser.StartINTerminal = new IncrementOperator();
            parser.Parse();
        }
/*Operator Unary */
        [TestMethod]
        public void TestOpUnary1()
        {
            var parser = new Parser(new Lexer(new InputStream("!")));
            parser.StartINTerminal = new UnaryOperator();
            parser.Parse();
        }

        [TestMethod]
        public void TestOpUnary2()
        {
            var parser = new Parser(new Lexer(new InputStream("~")));
            parser.StartINTerminal = new UnaryOperator();
            parser.Parse();
        }
        [TestMethod]
        public void TestOpUnary3()
        {
            var parser = new Parser(new Lexer(new InputStream("-")));
            parser.StartINTerminal = new UnaryOperator();
            parser.Parse();
        }

/*Multiplicative Operator*/
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestMultOperator1()
        {
            var parser = new Parser(new Lexer(new InputStream("*")));
            parser.StartINTerminal = new MultiplicativeOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestMultOperator2()
        {
            var parser = new Parser(new Lexer(new InputStream("/")));
            parser.StartINTerminal = new MultiplicativeOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestMultOperator3()
        {
            var parser = new Parser(new Lexer(new InputStream("%")));
            parser.StartINTerminal = new MultiplicativeOperator();
            parser.Parse();
        }
/*Additive Operator*/
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAddOperator1()
        {
            var parser = new Parser(new Lexer(new InputStream("-")));
            parser.StartINTerminal = new AdditiveOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAddOperator2()
        {
            var parser = new Parser(new Lexer(new InputStream("+")));
            parser.StartINTerminal = new AdditiveOperator();
            parser.Parse();
        }

/*Shift Operators*/

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestShiftOperator()
        {
            var parser = new Parser(new Lexer(new InputStream(">>")));
            parser.StartINTerminal = new ShiftOperator();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestShiftOperator2()
        {
            var parser = new Parser(new Lexer(new InputStream("<<")));
            parser.StartINTerminal = new ShiftOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestShiftOperator3()
        {
            var parser = new Parser(new Lexer(new InputStream(">>>")));
            parser.StartINTerminal = new ShiftOperator();
            parser.Parse();
        }
/*Relational Operators*/
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestRelationalOperator1()
        {
            var parser = new Parser(new Lexer(new InputStream(">")));
            parser.StartINTerminal = new RelationalOperator();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestRelationalOperator2()
        {
            var parser = new Parser(new Lexer(new InputStream(">=")));
            parser.StartINTerminal = new RelationalOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestRelationalOperator3()
        {
            var parser = new Parser(new Lexer(new InputStream("<")));
            parser.StartINTerminal = new RelationalOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestRelationalOperator4()
        {
            var parser = new Parser(new Lexer(new InputStream("<=")));
            parser.StartINTerminal = new RelationalOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestRelationalOperator5()
        {
            var parser = new Parser(new Lexer(new InputStream("==")));
            parser.StartINTerminal = new RelationalOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestRelationalOperator6()
        {
            var parser = new Parser(new Lexer(new InputStream("===")));
            parser.StartINTerminal = new RelationalOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestRelationalOperator7()
        {
            var parser = new Parser(new Lexer(new InputStream("!==")));
            parser.StartINTerminal = new RelationalOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestRelationalOperator8()
        {
            var parser = new Parser(new Lexer(new InputStream("!=")));
            parser.StartINTerminal = new RelationalOperator();
            parser.Parse();
        }
/*Asignment Operator*/
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAsigOperator1()
        {
            var parser = new Parser(new Lexer(new InputStream("=")));
            parser.StartINTerminal = new AssignmentOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAsigOperator2()
        {
            var parser = new Parser(new Lexer(new InputStream("*=")));
            parser.StartINTerminal = new AssignmentOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAsigOperator3()
        {
            var parser = new Parser(new Lexer(new InputStream("/=")));
            parser.StartINTerminal = new AssignmentOperator();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAsigOperator4()
        {
            var parser = new Parser(new Lexer(new InputStream("%=")));
            parser.StartINTerminal = new AssignmentOperator();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAsigOperator5()
        {
            var parser = new Parser(new Lexer(new InputStream("+=")));
            parser.StartINTerminal = new AssignmentOperator();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAsigOperator6()
        {
            var parser = new Parser(new Lexer(new InputStream("-=")));
            parser.StartINTerminal = new AssignmentOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAsigOperator7()
        {
            var parser = new Parser(new Lexer(new InputStream("<<=")));
            parser.StartINTerminal = new AssignmentOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAsigOperator8()
        {
            var parser = new Parser(new Lexer(new InputStream(">>=")));
            parser.StartINTerminal = new AssignmentOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAsigOperator9()
        {
            var parser = new Parser(new Lexer(new InputStream("&=")));
            parser.StartINTerminal = new AssignmentOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAsigOperator10()
        {
            var parser = new Parser(new Lexer(new InputStream("^=")));
            parser.StartINTerminal = new AssignmentOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAsigOperator11()
        {
            var parser = new Parser(new Lexer(new InputStream("|=")));
            parser.StartINTerminal = new AssignmentOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAsigOperator12()
        {
            var parser = new Parser(new Lexer(new InputStream(">>>=")));
            parser.StartINTerminal = new AssignmentOperator();
            parser.Parse();
        }


    }
}