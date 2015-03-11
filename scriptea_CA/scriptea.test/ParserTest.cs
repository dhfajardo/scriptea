using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using scriptea.Lexical;
using scriptea.Lexical.Input;
using scriptea.Parsing;
using scriptea.Parsing.Expressions;
using scriptea.Parsing.Expressions.Constructor;
using scriptea.Parsing.Literals;
using  scriptea.Parsing.Operators;
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
    public class ParserTest
    {
        

        [TestMethod]
        public void TestOpUnary()
        {
            var parser = new Parser(new Lexer(new InputStream("!")));
            parser.StartINTerminal = new UnaryOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestMultOperator()
        {
            var parser = new Parser(new Lexer(new InputStream("%")));
            parser.StartINTerminal = new MultiplicativeOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAddOperator()
        {
            var parser = new Parser(new Lexer(new InputStream("-")));
            parser.StartINTerminal = new AdditiveOperator();
            parser.Parse();
        }
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
        public void TestRelationalOperator()
        {
            var parser = new Parser(new Lexer(new InputStream("!=")));
            parser.StartINTerminal = new RelationalOperator();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAsigOperator()
        {
            var parser = new Parser(new Lexer(new InputStream(">>>=")));
            parser.StartINTerminal = new AssignmentOperator();
            parser.Parse();
        }

        /*LITERALES*/
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestBoolLiteral()
        {
            var parser = new Parser(new Lexer(new InputStream("false")));
            parser.StartINTerminal = new BooleanLiteral();
            parser.Parse();
        }

        /*EXPRESIONES*/
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestExPrimary()
        {
            var parser = new Parser(new Lexer(new InputStream("\"dsndsfskjand\"")));
            parser.StartINTerminal = new PrimaryExpression();
            parser.Parse();
        }

        /*ACCESOR LIST*/
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAccesorList()
        {
            ArrayList list = new ArrayList
            {
                ".id[2]().algo()"
                ,".id.id.id"
                ,"[(alan)*4 = andres]"
                ,"[(alan*odir)%4]"
                ,"(alan7[44])"
            };
            foreach (var ind in list)
            {
                var parser = new Parser(new Lexer(new InputStream(ind.ToString())));
                parser.StartINTerminal = new AccesorList();
                parser.Parse();   
            }
        }

        /*MEMBER EXPRESSION*/
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestMemberExp()
        {
            var parser = new Parser(new Lexer(new InputStream("id.a[er]().ij")));
            parser.StartINTerminal = new MemberExpression();
            parser.Parse();
        }

        /*CONSTRUCTOR*/
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestConstCall()
        {
            ArrayList list = new ArrayList
            {
                "id()"
                ,"id(4+3)"
                ,
            };
            var parser = new Parser(new Lexer(new InputStream("id.ok()")));
            parser.StartINTerminal = new ConstructorCall();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestUnaryExp()
        {
            ArrayList list = new ArrayList
            {
                "!!!!!!++id"
                ,"id.id[3]--"
                ,"id2.id4[alan]++"
                ,"!!!!~~~~~-!-!~-!!!id"
            };
            foreach (var ind in list)
            {
                var parser = new Parser(new Lexer(new InputStream(ind.ToString())));
                parser.StartINTerminal = new UnaryExpression();
                parser.Parse();
            }
        }

       /* [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestMultExp()
        {
            ArrayList list = new ArrayList
            {
                "~~~~~!!!!!~!~!~!~!~!~!-----~~!~!!!3*~!~!~"
                ,"id()[3]*34"
            };
            foreach (var ls in list)
            {
                var parser = new Parser(new Lexer(new InputStream(ls.ToString()
                    )));
                parser.StartINTerminal = new MultiplicativeExpression();
                parser.Parse();
            }
            
        }
        */
        
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAddExp()
        {
            var parser = new Parser(new Lexer(new InputStream("p+9")));
            parser.StartINTerminal = new AdditiveExpression();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestShiftExp()
        {
            var parser = new Parser(new Lexer(new InputStream("id>>4")));
            parser.StartINTerminal = new ShiftExpression();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestRelExp()
        {
            var parser = new Parser(new Lexer(new InputStream("kd==d")));
            parser.StartINTerminal = new RelationalExpression();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestBitAExp()
        {
            var parser = new Parser(new Lexer(new InputStream("id&vd")));
            parser.StartINTerminal = new BitwiseAndExpression();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestBitXExp()
        {
            var parser = new Parser(new Lexer(new InputStream("id&id")));
            parser.StartINTerminal = new BitwiseXorExpression();
            parser.Parse();
        }

        
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestBitOExp()
        {
            var parser = new Parser(new Lexer(new InputStream("id^id3")));
            parser.StartINTerminal = new BitwiseOrExpression();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAndExpression()
        {
            ArrayList list = new ArrayList
            {
                "id--&&id"
                ,"id|id3"
            };
            foreach (var uni in list)
            {
                var parser = new Parser(new Lexer(new InputStream(uni.ToString())));
                parser.StartINTerminal = new AndExpression();
                parser.Parse();
            }
            
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestOrExp()
        {
            var parser = new Parser(new Lexer(new InputStream("id||id")));
            parser.StartINTerminal = new OrExpression();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestCondExp()
        {
            var parser = new Parser(new Lexer(new InputStream("id?a:b")));
            parser.StartINTerminal = new ConditionalExpression();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAssigExp()
        {
            var parser = new Parser(new Lexer(new InputStream("var1 = var2")));
            parser.StartINTerminal = new AssignmentExpression();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestExpressionP()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new Expressionp();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestExpression()
        {
            var parser = new Parser(new Lexer(new InputStream("1")));
            parser.StartINTerminal = new Expression();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestExpressionOPT()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new ExpressionOpt();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestVar()
        {
            var parser = new Parser(new Lexer(new InputStream("id=3")));
            parser.StartINTerminal = new Variable();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestVarListP()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new VariableListp();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestVarList()
        {
            var parser = new Parser(new Lexer(new InputStream("id,id,id")));
            parser.StartINTerminal = new VariableList();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestVarOPT()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new VarOpt();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestVariablesOrExpression()
        {
            ArrayList list = new ArrayList
            {
                "var id"
                ,"var id, id"
                ,"var id"
            };
            foreach (var lt in list)
            {
                var parser = new Parser(new Lexer(new InputStream(lt.ToString())));
                parser.StartINTerminal = new VariablesOrExpression();
                parser.Parse();
            }
            
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestThrowStmP()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new ThrowStatementp();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestThrowStm()
        {
            var parser = new Parser(new Lexer(new InputStream("throw")));
            parser.StartINTerminal = new ThrowStatement();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestFinBlock()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new FinallyBlock();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestCatchBlock()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new CatchBlock();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestCaseC()
        {
            var parser = new Parser(new Lexer(new InputStream("case a=b:")));
            parser.StartINTerminal = new CaseClause();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestCaseCList()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new CaseClauseList();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestDefClause()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new DefauldClause();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestCaseBlock()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new CaseBlock();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestForCond()
        {
            var parser = new Parser(new Lexer(new InputStream("var id; id<1;id++")));
            parser.StartINTerminal = new ForConditions();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestIfNot()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new IfNot();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestStmP()
        {
            var parser = new Parser(new Lexer(new InputStream("{}")));
            parser.StartINTerminal = new Statementp();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestStm()
        {
            ArrayList list = new ArrayList
            {
                "for (i = 0; i < cars.length; i++) {    text += cars[i] + \"<br>\";}"
                ,"for (i = 0, len = cars.length, text = \"\"; i < len; i++) {    text += cars[i] + \"<br>\";}"
                ,"for (; i < len; i++) {    text += cars[i] + \"<br>\";}"
            };
            foreach (var ind in list)
            {
                var parser = new Parser(new Lexer(new InputStream(ind.ToString())));
                parser.StartINTerminal = new Statement();
                parser.Parse();
            }
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestStmList()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new StatementList();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestCmpStm()
        {
            var parser = new Parser(new Lexer(new InputStream("{}")));
            parser.StartINTerminal = new CompoundStatement();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestParamListP()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new ParameterListp();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestParamList()
        {
            var parser = new Parser(new Lexer(new InputStream("id,id,id,id")));
            parser.StartINTerminal = new ParameterList();
            parser.Parse();
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestParamListOPT()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new ParameterListOpt();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestElem()
        {
            var parser = new Parser(new Lexer(new InputStream("function id (id,id){}")));
            parser.StartINTerminal = new Element();
            parser.Parse();
        }

        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestPrg()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new Program();
            parser.Parse();
        }

/*PRUEBAS QUE NO PASAN PARA EL TREE*/
/*
//----------------------------------
        //AdditiveExpressionp espera de parametro el operador Izq.
        [TestMethod]
        public void TestAddExpP()
        {
            var parser = new Parser(new Lexer(new InputStream("++34")));
            parser.StartINTerminal = new AdditiveExpressionp();
            parser.Parse();
        }
//----------------------------------
        //AddExpressionp espera de parametro el operador Izq.
        [TestMethod]
        public void TestAndExpP()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new AndExpressionp();
            parser.Parse();
        }
//----------------------------------
        //AssigmentExpressionp espera de parametro un operador Izq.
        [TestMethod]
        public void TestAssigExpP()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new AssignmentExpressionp();
            parser.Parse();
        }
//----------------------------------
        //BitwiseAndExpressionp espera de parametro un operador Izq.
        [TestMethod]
        public void TestBitAExpP()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new BitwiseAndExpressionp();
            parser.Parse();
        }
//----------------------------------
        //BitwiseOrExpressionp espera de parametro un operador Izq.
        [TestMethod]
        public void TestBitOExpP()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new BitwiseOrExpressionp();
            parser.Parse();
        }
//----------------------------------
        //BitwiseXorExpressionp espera de parametro un operador Izq.
        [TestMethod]
        public void TestBitXExpP()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new BitwiseXorExpressionp();
            parser.Parse();
        }
//----------------------------------
        //Variablep espera de parametro un operador Izq.
        [TestMethod]
        public void TestVarP()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new Variablep();
            parser.Parse();
        }
//----------------------------------
        //MultiplicativeExpressionp espera de parametro un operador Izq.
        [TestMethod]
        public void TestMultExpP()
        {
            var parser = new Parser(new Lexer(new InputStream("*id().o")));
            parser.StartINTerminal = new MultiplicativeExpressionp();
            parser.Parse();
        }
//----------------------------------
        //IncrementOperator espera el parametro "Flag"
        [TestMethod]
        public void TestOPInc()
        {
            var parser = new Parser(new Lexer(new InputStream("++")));
            parser.StartINTerminal = new IncrementOperator();
            parser.Parse();
        }
//----------------------------------
        //DecrementOperator espera el parametro "Flag"
        [TestMethod]
        public void TestOPDec()
        {
            var parser = new Parser(new Lexer(new InputStream("--")));
            parser.StartINTerminal = new DecrementOperator();
            parser.Parse();
        }
//----------------------------------
        //OrExpressionp espera de parametro un operador Izq.
        [TestMethod]
        public void TestOrExpP()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new OrExpressionp();
            parser.Parse();
        }
//----------------------------------
        //ShiftExpressionp espera de parametro un operador Izq.
        [TestMethod]
        public void TestShiftExpP()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new ShiftExpressionp();
            parser.Parse();
        }
//----------------------------------
        //RelationalExpressionp espera de parametro un operador Izq.
        [TestMethod]
        public void TestRelExpP()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new RelationalExpressionp();
            parser.Parse();
        }
//----------------------------------
        //UnaryExpressionp espera de parametro un operador Izq.
        [TestMethod]
        public void TestUnaryExpP()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new UnaryExpressionp();
            parser.Parse();
        }
//---------------------------------- 
        //ConditionalExpressionp espera de parametro un operador Izq.
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestCondExpP()
        {
            var parser = new Parser(new Lexer(new InputStream("")));
            parser.StartINTerminal = new ConditionalExpressionp();
            parser.Parse();
        }
 */
    }
}
