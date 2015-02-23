using System.Collections.Generic;
using scriptea.Lexical;

namespace scriptea.Parsing.Expressions
{
    public  class ExpressionOpt:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.Id
                || parser.CurrenToken.Type == TokenType.PmLeftParent
                || parser.CurrenToken.Type == TokenType.PmLeftBracket
                || parser.CurrenToken.Type == TokenType.LitInteger
                || parser.CurrenToken.Type == TokenType.LitString
                || parser.CurrenToken.Type == TokenType.LitFloat
                || parser.CurrenToken.Type == TokenType.LitBool
                || parser.CurrenToken.Type == TokenType.KwNull
                || parser.CurrenToken.Type == TokenType.OpNot
                || parser.CurrenToken.Type == TokenType.OpSub
                || parser.CurrenToken.Type == TokenType.OpNotBit
                || parser.CurrenToken.Type == TokenType.OpInc
                || parser.CurrenToken.Type == TokenType.OpDec
                || parser.CurrenToken.Type == TokenType.KwNew)
            {
                new Expression().Process(parser, parameters);
            }
            else
            {
                //Epsilon
            }
            return null;
        }
    }
}