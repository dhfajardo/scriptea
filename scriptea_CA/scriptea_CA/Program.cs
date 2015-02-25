using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;
using scriptea.Lexical;

namespace scriptea_CA
{
    class Program
    {
        static void Main(string[] args)
        {
            InputStream _input = new InputStream(System.IO.File.ReadAllText(@"C:\Users\hnfajardoa\Documents\GitHub\scriptea\Test\Parser\prgTest2.txt"));
            Token _token = new Token();
            Lexer _lexer = new Lexer();
            try
            {
                _lexer.Input = _input;
                _token = _lexer.GetNextToken();
                Console.WriteLine("[" + _token.Type.ToString() + "]" + " " + 
                        "[" + "Row:" + _token.Row.ToString() + ", Column:" + _token.Column.ToString() + "]" + " " + _token.LexemeVal);
                while (_token.Type != TokenType.Eof)
                {
                    _token = _lexer.GetNextToken();
                    Console.WriteLine("[" + _token.Type.ToString() + "]" + " " + 
                        "[" + "Row:" + _token.Row.ToString() + ", Column:" + _token.Column.ToString() + "]" + " " + _token.LexemeVal);
                }
            }
            catch(LexerException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
