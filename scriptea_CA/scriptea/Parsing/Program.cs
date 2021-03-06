﻿using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Parameters;
using scriptea.Parsing.Statements;
using scriptea.Tree.Statement;

namespace scriptea.Parsing
{
    public class Program:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwFunction
                || parser.CurrenToken.Type == TokenType.PmSemicolon
                || parser.CurrenToken.Type == TokenType.KwIf
                || parser.CurrenToken.Type == TokenType.KwWhile
                || parser.CurrenToken.Type == TokenType.KwFor
                || parser.CurrenToken.Type == TokenType.KwBreak
                || parser.CurrenToken.Type == TokenType.KwContinue
                || parser.CurrenToken.Type == TokenType.KwThrow
                || parser.CurrenToken.Type == TokenType.KwSwitch
                || parser.CurrenToken.Type == TokenType.KwDo
                || parser.CurrenToken.Type == TokenType.KwReturn
                || parser.CurrenToken.Type == TokenType.KwTry
                || parser.CurrenToken.Type == TokenType.KwVar
                || parser.CurrenToken.Type == TokenType.Id
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
                var _singleElement = (StatementNode) new Element().Process(parser, parameters);
                var _elements = (List<StatementNode>) this.Process(parser, parameters);
                _elements.Insert(0,_singleElement);
                return _elements;
            }
            else
            {
                return new List<StatementNode>();
            }
        }
    }
}