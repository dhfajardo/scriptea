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
    }
}