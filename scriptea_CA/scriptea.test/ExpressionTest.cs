using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using scriptea.Lexical;
using scriptea.Lexical.Input;
using scriptea.Parsing;
using scriptea.Parsing.Expressions;
using scriptea.Parsing.Literals;
using scriptea.Parsing.Operators;

namespace scriptea.test
{
    [TestClass]
    public class ExpressionTest
    {
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestPrimaryExpression()
        {
            ArrayList list = new ArrayList
            {
                "1",
                "332.32",
                "\"hola\"",
                "true",
                "false"
                ,"(id=3)"
                ,"[3,3,2,id]"
            };
            foreach (var tokenType in list)
            {
                var parser = new Parser(new Lexer(new InputStream(tokenType.ToString())));
                parser.StartINTerminal = new PrimaryExpression();
                parser.Parse();
            }
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestMemberExpression()
        {
            ArrayList list = new ArrayList
            {
                "id"
                ,"id.id"
                ,"id[8+3]"
                ,"id(bool).id"
                ,"id[1]"
                ,"id.id[id[4]]"
            };
            foreach (var tokenType in list)
            {
                var parser = new Parser(new Lexer(new InputStream(tokenType.ToString())));
                parser.StartINTerminal = new MemberExpression();
                parser.Parse();
            }
        }
        [TestMethod]
        //[ExpectedException(typeof(ParserException))]
        public void TestAssignmentExpression()
        {
            ArrayList list = new ArrayList
            {
                "ID++"
                ,"id--"
                ,"--Id"
                ,"++INC"
                ,"(id)"
                ,"(true)"
                ,"(false)"
                ,"(32.323)"
                ,"(null)"
                ,"(\"String\")"
                ,"[]"
                ,"[3]*3+(1*3)"
                ,"([43>3])"
                ,"[hola + 43/(mul--)]"
                ,"45/58*96%2+id--"
                ,"id+=3"
                ,"id?var1=var2:3"
                ,"id[4]?id[3]:id[3]"
                ,"new id.id() = 4"
                ,"id.f[id.a[4]]()"
                ,"id.f[id.a[4]](id.f[id.a[4]]())"
                ,"id.f[id.a[4]]()"
                ,"new id(id.f[id.a[4]]())"
                ,"new id.id.id.id4(id.f[id.a[4]]())"
                ,"new id.id.id(id.f[id.a[id.a[((a++) * (b--))/d%4]]]())"
                ,"var1[3].id() = alan"
            };
            foreach (var tokenType in list)
            {
                var parser = new Parser(new Lexer(new InputStream(tokenType.ToString())));
                parser.StartINTerminal = new AssignmentExpression();
                parser.Parse();
            }
        }
    }
}