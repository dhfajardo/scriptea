using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using scriptea.Lexical;
using scriptea.Lexical.Input;
using scriptea.Parsing;
using scriptea.Parsing.Expressions;
using scriptea.Parsing.Statements;
using scriptea.Parsing.Variables;
using scriptea.Tree;
using scriptea.Tree.Expression;
using scriptea.Tree.Statement;

namespace scriptea.test
{
    [TestClass]
    public class InterpreterStatementTest
    {
        [TestMethod]
        public void InterpreterVarOrExp()
        {
            SymbolTable _SymbolTable=new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a = 1;b=2;a+=1;")));
            parser.StartINTerminal = new StatementList();
            var _result =(List<StatementNode>) parser.Parse();
            foreach (var statementNode in _result)
            {
                statementNode.Interpret(_SymbolTable);
            }
        }

        [TestMethod]
        public void InterpreterOP_1s()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a = 1;b=a++;c=++a;")));
            parser.StartINTerminal = new StatementList();
            var _result = (List<StatementNode>)parser.Parse();
            foreach (var statementNode in _result)
            {
                statementNode.Interpret(_SymbolTable);
            }
        }
        [TestMethod]
        public void InterpreterIf()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a = 1;if(a>0)b=7;else b=9;")));
            parser.StartINTerminal = new StatementList();
            var _result = (List<StatementNode>)parser.Parse();
            foreach (var statementNode in _result)
            {
                statementNode.Interpret(_SymbolTable);
            }
        }
        [TestMethod]
        public void InterpreterIfNot()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a = 1;if(a<1)b=7;else b=9;")));
            parser.StartINTerminal = new StatementList();
            var _result = (List<StatementNode>)parser.Parse();
            foreach (var statementNode in _result)
            {
                statementNode.Interpret(_SymbolTable);
            }
        }

        [TestMethod]
        public void InterpreterWhile()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream("a = 1;b=0;while(a<5){ b+=2;a++;}")));
            parser.StartINTerminal = new StatementList();
            var _result = (List<StatementNode>)parser.Parse();
            foreach (var statementNode in _result)
            {
                statementNode.Interpret(_SymbolTable);
            }
        }
        [TestMethod]
        public void InterpreterWhileBreak()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream(@"a = 1;
                                                                b=0;
                                                                while(true)
                                                                { 
                                                                    if(a==4)
                                                                        break;
                                                                    b+=2;
                                                                    a++;
                                                                }")));
            parser.StartINTerminal = new StatementList();
            var _result = (List<StatementNode>)parser.Parse();
            foreach (var statementNode in _result)
            {
                statementNode.Interpret(_SymbolTable);
            }
        }

        [TestMethod]
        public void InterpreterWhileContinue()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream(@"a = 1;
                                                                b=0;
                                                                while(true)
                                                                { 
                                                                    if(a==4)
                                                                        break;
                                                                    if(a==3)
                                                                    {
                                                                        a++;
                                                                        continue;
                                                                    }
                                                                    b+=2;
                                                                    a++;
                                                                }")));
            parser.StartINTerminal = new StatementList();
            var _result = (List<StatementNode>) parser.Parse();
            foreach (var statementNode in _result)
            {
                statementNode.Interpret(_SymbolTable);
            }
        }

        [TestMethod]
        public void InterpreterDoWhile()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream(@"a = 1;
                                                                b=0;
                                                                do
                                                                { 
                                                                    b+=2;
                                                                    a++;
                                                                }while(a<5)")));
            parser.StartINTerminal = new StatementList();
            var _result = (List<StatementNode>)parser.Parse();
            foreach (var statementNode in _result)
            {
                statementNode.Interpret(_SymbolTable);
            }
        }

        [TestMethod]
        public void InterpreterDoWhileBreak()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream(@"a = 1;
                                                                b=0;
                                                                do
                                                                { 
                                                                    if(a==4)
                                                                        break;
                                                                    b+=2;
                                                                    a++;
                                                                }while(true)")));
            parser.StartINTerminal = new StatementList();
            var _result = (List<StatementNode>)parser.Parse();
            foreach (var statementNode in _result)
            {
                statementNode.Interpret(_SymbolTable);
            }
        }

        [TestMethod]
        public void InterpreterDoWhileContinue()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream(@"a = 1;
                                                                b=0;
                                                                do
                                                                { 
                                                                    if(a==4)
                                                                        break;
                                                                    if(a==3)
                                                                    {
                                                                        a++;
                                                                        continue;
                                                                    }
                                                                    b+=2;
                                                                    a++;
                                                                }while(true)")));
            parser.StartINTerminal = new StatementList();
            var _result = (List<StatementNode>)parser.Parse();
            foreach (var statementNode in _result)
            {
                statementNode.Interpret(_SymbolTable);
            }
        }
        [TestMethod]
        public void InterpreterFor()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream(@"var a=0;
                                                                for(id=0;id<10;id++)
                                                                {
                                                                    if(id>5)
                                                                        a+=3;
                                                                    id++;
                                                                }")));
            parser.StartINTerminal = new StatementList();
            var _result = (List<StatementNode>)parser.Parse();
            foreach (var statementNode in _result)
            {
                statementNode.Interpret(_SymbolTable);
            }
        }
        [TestMethod]
        public void InterpreterForBreak()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream(@"var a=0;
                                                                for(id=0;id<10;id++)
                                                                {
                                                                    if(id==6)
                                                                    {
                                                                        a=-5;
                                                                        break;
                                                                    }
                                                                    id++;
                                                                }")));
            parser.StartINTerminal = new StatementList();
            var _result = (List<StatementNode>)parser.Parse();
            foreach (var statementNode in _result)
            {
                statementNode.Interpret(_SymbolTable);
            }
        }
        [TestMethod]
        public void InterpreterForContinue()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream(@"var a=0;
                                                                var b=10;
                                                                for(id=0;id<10;id++)
                                                                {
                                                                    if(id>=6)
                                                                    {
                                                                        a=-5;
                                                                    }
                                                                    else
                                                                    {
                                                                        id++;
                                                                        continue;
                                                                    }
                                                                    b--;
                                                                    id++;
                                                                }")));
            parser.StartINTerminal = new StatementList();
            var _result = (List<StatementNode>)parser.Parse();
            foreach (var statementNode in _result)
            {
                statementNode.Interpret(_SymbolTable);
            }
        }
        [TestMethod]
        public void InterpreterSwitch()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream(@" var id=1;
                                                                var count = 3;
                                                                switch(id)
                                                                {
                                                                    case 1: 
                                                                        count++; 
                                                                        break; 
                                                                    case 2: 
                                                                        if(true) 
                                                                            count--;
                                                                }")));
            parser.StartINTerminal = new StatementList();
            var _result = (List<StatementNode>)parser.Parse();
            foreach (var statementNode in _result)
            {
                statementNode.Interpret(_SymbolTable);
            }
        }
        [TestMethod]
        public void InterpreterSwitchDefauld()
        {
            SymbolTable _SymbolTable = new SymbolTable();
            var parser = new Parser(new Lexer(new InputStream(@" var id=2;
                                                                var count = 2;
                                                                switch(id)
                                                                {
                                                                    case 1: 
                                                                        count++; 
                                                                        break; 
                                                                    default:
                                                                         count = 100;
                                                                         break;
                                                                    case 2: 
                                                                        if(true) 
                                                                            count--;
                                                                        break;
                                                                    
                                                                }")));
            parser.StartINTerminal = new StatementList();
            var _result = (List<StatementNode>)parser.Parse();
            foreach (var statementNode in _result)
            {
                statementNode.Interpret(_SymbolTable);
            }
        }
    }
}