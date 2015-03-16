using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using scriptea.Lexical;
using scriptea.Lexical.Input;
using scriptea.Parsing;
using scriptea.Parsing.Expressions;
using scriptea.Parsing.Statements;
using scriptea.Tree;
using scriptea.Tree.Expression;
using scriptea.Tree.Statement;

namespace scriptea.test
{
    [TestClass]
    public class InterpreterTesting
    {
        [TestMethod]
        public void InterpreterExpression_1()
        {
            SymbolTable _SymbolTable=new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a = new System.Collections.ArrayList()")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result =(ExpressionNode) parser.Parse();
            _result.Evaluate(_SymbolTable);
        }
        [TestMethod]
        public void InterpreterEquivTrue()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a = 1==1?4:3")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(4,_SymbolTable.GetSymbol("a"));
        }

        [TestMethod]
        public void InterpreterEquivFalse()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a = 1==1.01?4:3")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(3,_SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterEqualTrue()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a = 1===1?4:3")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(4,_SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterEqualFalse()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a = 1===true?4:3")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(3,_SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterEqualFalse_1()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a = !(1===true)?4:3")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(4, _SymbolTable.GetSymbol("a"));
        }

        [TestMethod]
        public void InterpreterSum()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a= 1+1")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(2, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterSub()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a= 4-1")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(3, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterAssigSum()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a+=1")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(1, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterAssigSub()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a-=1")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(1, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterIncPos()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=a++")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(1, _SymbolTable.GetSymbol("a"));
        }

        [TestMethod]
        public void InterpreterDiv()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=4/2")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(2, _SymbolTable.GetSymbol("a"));
        }

        [TestMethod]
        public void InterpreterMul()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=4*2")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(8, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterMod()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=4%2")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(0, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterNotEquiv()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=4!=2")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(true, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterNotEqual()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=!(4!==2)")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(true, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterLessThan()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=!(4<2)")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(true, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterGreaterThan()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=!(4>2)")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(false, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterGreaterEqualThan()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=!(4>=2)")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(false, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreteLessEqualThan()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=!(4<=2)")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(true, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterShiftRight()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=10>>2")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(2, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterShiftLeft()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=10<<2")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(40, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterShiftRightZeroFill()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=-10>>2")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(-3, _SymbolTable.GetSymbol("a"));
        }

        [TestMethod]
        public void InterpreterNotBit()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=~2")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(-3, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterNot()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=!false")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(true, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterOr()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a= 1==3||true==true?\"true\":\"false\"")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual("true", _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterBitwiseOr()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=2|8")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(10, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterBitwiseXOr()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=3^13")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(14, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterNull()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=null")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(null, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterBitwiseAnd()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=14&5")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(4, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterTernary()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=(1==1 && false==false)?true:false")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(true, _SymbolTable.GetSymbol("a"));
        }

        [TestMethod]
        public void InterpreterTernary_2()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=(1==1 && false==true)?true:false")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(false, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterArray()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a = [1,2,\"tres\"]")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            //Assert.AreEqual(false, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterArray_2()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a = [1,2,\"tres\",[1,2]]")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            //Assert.AreEqual(false, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterOperadores_1()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a= 3+1*5")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(8, _SymbolTable.GetSymbol("a"));
        }

        [TestMethod]
        public void InterpreterOperadores_2()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a= 3+1*5/2+5/4")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(6.75, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterOperadores_3()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a= 3+1*5+8/4>>5")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(0, _SymbolTable.GetSymbol("a"));
        }
        [TestMethod]
        public void InterpreterOperadores_4()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a=5<<5")));
            parser.StartINTerminal = new AssignmentExpression();
            var _result = (ExpressionNode)parser.Parse();
            _result.Evaluate(_SymbolTable);
            Assert.AreEqual(160, _SymbolTable.GetSymbol("a"));
        }
    }
}