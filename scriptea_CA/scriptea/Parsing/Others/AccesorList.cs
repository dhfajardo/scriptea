using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;
using scriptea.Parsing.Expressions;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Others
{
    public  class AccesorList:INTerminal 
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.PmDot)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.Id)
                {
                    string _idName = parser.CurrenToken.LexemeVal;
                    parser.NextToken();
                    var _result = (Accesor) this.Process(parser, null);
                    if (_result is FunctionAccesor)
                    {
                        var _function = (FunctionAccesor) _result;
                        _function.Name = _idName;
                        return _function;
                    }
                    else
                    {
                        var _field = new FieldAccesor { Name = _idName };
                        _field.NextAccesor = _result;
                        return _field;
                    }
                }
                else
                {
                    throw new ParserException("This was expected a Identifier, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else if (parser.CurrenToken.Type == TokenType.PmLeftBracket)
            {
                parser.NextToken();
                var _indexEp =(ExpressionNode) new AssignmentExpression().Process(parser, null);
                if (parser.CurrenToken.Type == TokenType.PmRightBracket)
                {
                    parser.NextToken();
                    var _index = new IndexAcessor {IndexList = _indexEp};
                    _index.NextAccesor =(Accesor)this.Process(parser, parameters);
                    return _index;
                }
                else
                {
                    throw new ParserException("This was expected ], Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else if (parser.CurrenToken.Type == TokenType.PmLeftParent)
            {
                parser.NextToken();
                List<ExpressionNode> _listEp = (List<ExpressionNode>)new ExpressionOpt().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.PmRightParent)
                {
                    parser.NextToken();
                    var _function = new FunctionAccesor {Name = "",ParameterList = _listEp};
                    _function.NextAccesor = (Accesor)this.Process(parser, parameters);
                    return _function;
                }
                else
                {
                    throw new ParserException("This was expected ), Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else
            {
                return null;
            }
        }
    }
}
