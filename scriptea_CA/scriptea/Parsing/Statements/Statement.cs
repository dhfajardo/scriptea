using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Expressions;
using scriptea.Parsing.Statements.Blocks;
using scriptea.Parsing.Statements.Clause;
using scriptea.Parsing.Statements.Elements;
using scriptea.Parsing.Variables;
using scriptea.Tree.Expression;
using scriptea.Tree.Others;
using scriptea.Tree.Statement;

namespace scriptea.Parsing.Statements
{
    public class Statement:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.PmSemicolon)
            {
                parser.NextToken();
                return new StatementNode();
            }
            else if (parser.CurrenToken.Type == TokenType.KwIf)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.PmLeftParent)
                {
                    parser.NextToken();
                    var _evaluation = (ExpressionNode)new AssignmentExpression().Process(parser, parameters);
                    if (parser.CurrenToken.Type == TokenType.PmRightParent)
                    {
                        parser.NextToken();
                        var _ifCode =(List<StatementNode>) new Statementp().Process(parser, parameters);
                        var _ifNotCode = (ElseNode)new IfNot().Process(parser, parameters);
                        var _if = new IfNode {EvaluationNode = _evaluation, IfCode = _ifCode, IfNotCode = _ifNotCode};
                        return _if;
                    }
                    else
                    {
                        throw new ParserException("This was expected ) Received: [" +
                       parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                       + ", Column: " + parser.CurrenToken.Column);
                    }
                }
                else
                {
                    throw new ParserException("This was expected ( Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else if (parser.CurrenToken.Type == TokenType.KwWhile)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.PmLeftParent)
                {
                    parser.NextToken();
                    var _evaluation = (ExpressionNode)new AssignmentExpression().Process(parser, parameters);
                    if (parser.CurrenToken.Type == TokenType.PmRightParent)
                    {
                        parser.NextToken();
                        var _whileCode =(List<StatementNode>) new Statementp().Process(parser, parameters);
                        var _while = new WhileNode {EvaluationNode = _evaluation, CodeNode = _whileCode};
                        return _while;
                    }
                    else
                    {
                        throw new ParserException("This was expected ) Received: [" +
                       parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                       + ", Column: " + parser.CurrenToken.Column);
                    }
                }
                else
                {
                    throw new ParserException("This was expected ( Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else if (parser.CurrenToken.Type == TokenType.KwFor)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.PmLeftParent)
                {
                    parser.NextToken();
                    var _for = (ForNode) new ForConditions().Process(parser, parameters);
                    if (parser.CurrenToken.Type == TokenType.PmRightParent)
                    {
                        parser.NextToken();
                        var _forCode = (List<StatementNode>) new Statementp().Process(parser, parameters);
                        _for.CodeNode = _forCode;
                        return _for;
                    }
                    else
                    {
                        throw new ParserException("This was expected ) Received: [" +
                       parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                       + ", Column: " + parser.CurrenToken.Column);
                    }
                }
                else
                {
                    throw new ParserException("This was expected ( Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else if (parser.CurrenToken.Type == TokenType.KwBreak)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                {
                    parser.NextToken();
                    return new BreakNode();
                }
                else
                {
                    throw new ParserException("This was expected ; Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else if (parser.CurrenToken.Type == TokenType.KwContinue)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                {
                    parser.NextToken();
                    return new ContinueNode();
                }
                else
                {
                    throw new ParserException("This was expected ; Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else if (parser.CurrenToken.Type == TokenType.KwThrow)
            {
                var _throw = new ThrowStatement().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                {
                    parser.NextToken();
                    return _throw;
                }
                else
                {
                    throw new ParserException("This was expected ; Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else if (parser.CurrenToken.Type == TokenType.KwSwitch)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.PmLeftParent)
                {
                    parser.NextToken();
                    var _evaluation =(ExpressionNode)new AssignmentExpression().Process(parser, parameters);
                    if (parser.CurrenToken.Type == TokenType.PmRightParent)
                    {
                        parser.NextToken();
                        if (parser.CurrenToken.Type == TokenType.PmLeftCurlyBracket)
                        {
                            parser.NextToken();
                            var _caseBlock =(BaseCaseNode) new CaseBlock().Process(parser, parameters);
                            if (parser.CurrenToken.Type == TokenType.PmRightCurlyBracket)
                            {
                                parser.NextToken();
                                var _switch = new SwitchNode {EvaluationNode = _evaluation, CaseBlockNode = _caseBlock};
                                return _switch;
                            }
                            else
                            {
                                throw new ParserException("This was expected } Received: [" +
                               parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                               + ", Column: " + parser.CurrenToken.Column);
                            }
                        }
                        else
                        {
                            throw new ParserException("This was expected { Received: [" +
                           parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                           + ", Column: " + parser.CurrenToken.Column);
                        }
                    }
                    else
                    {
                        throw new ParserException("This was expected ) Received: [" +
                           parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                           + ", Column: " + parser.CurrenToken.Column);
                    }
                }
                else
                {
                    throw new ParserException("This was expected ( Received: [" +
                           parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                           + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else if (parser.CurrenToken.Type == TokenType.KwDo)
            {
                parser.NextToken();
                var _doWhileCode = (List<StatementNode>)new Statementp().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.KwWhile)
                {
                    parser.NextToken();
                    if (parser.CurrenToken.Type == TokenType.PmLeftParent)
                    {
                        parser.NextToken();
                        var _evaluation =(ExpressionNode)new AssignmentExpression().Process(parser, parameters);
                        if (parser.CurrenToken.Type == TokenType.PmRightParent)
                        {
                            parser.NextToken();
                            var _doWhile = new DoWhileNode { EvaluationNode = _evaluation, CodeNode = _doWhileCode };
                            return _doWhile;
                        }
                        else
                        {
                            throw new ParserException("This was expected ) Received: [" +
                           parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                           + ", Column: " + parser.CurrenToken.Column);
                        }
                    }
                    else
                    {
                        throw new ParserException("This was expected ( Received: [" +
                       parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                       + ", Column: " + parser.CurrenToken.Column);
                    }
                }
                else
                {
                    throw new ParserException("This was expected the token: while, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else if (parser.CurrenToken.Type == TokenType.KwReturn)
            {
                parser.NextToken();
                var _returnEp =(List<ExpressionNode>)new ExpressionOpt().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                {
                    parser.NextToken();
                    var _return = new ReturnNode {ReturnExpressionNode = _returnEp};
                    return _return;
                }
                else
                {
                    throw new ParserException("This was expected ; Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else if (parser.CurrenToken.Type == TokenType.KwTry)
            {
                parser.NextToken();
                var _tryCode = (List<StatementNode>) new CompoundStatement().Process(parser, parameters);
                var _try = (TryNode) new CatchBlock().Process(parser, parameters);
                var _finally = (FinallyNode) new FinallyBlock().Process(parser, parameters);
                _try.FinallyCode = _finally;
                _try.TryCode = _tryCode;
                return _try;
            }
            else
            {
                var _varEp = new VariablesOrExpression().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                {
                    parser.NextToken();
                    return _varEp;
                }
                else
                {
                    throw new ParserException("This was expected ; Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
        }
    }
}
