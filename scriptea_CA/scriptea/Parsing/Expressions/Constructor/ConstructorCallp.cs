using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Others;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Expressions.Constructor
{
    public class ConstructorCallp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.PmLeftParent)
            {
                parser.NextToken();
                var _function = new FunctionAccesor();
                var _funcParameters = (List<ExpressionNode>)new ExpressionOpt().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.PmRightParent)
                {
                    parser.NextToken();
                    _function.ParameterList = _funcParameters;
                    return _function;
                }
                else
                {
                    throw new ParserException("This was expected ) in constructor call, Received: [" + 
                    parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                    + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else if (parser.CurrenToken.Type == TokenType.PmDot)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.Id)
                {
                    string _idName = parser.CurrenToken.LexemeVal;
                    parser.NextToken();
                    var _result = (Accesor) this.Process(parser, parameters);
                    if (_result is FunctionAccesor)
                    {
                        var _function = (FunctionAccesor) _result;
                        _function.Name = _idName;
                        return _function;
                    }
                    else
                    {
                        var _field = new FieldAccesor() {Name = _idName};
                        _field.NextAccesor = _result;
                        return _field;
                    }
                }
                else
                {
                    throw new ParserException("This was expected a Identifier in constructor call, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);

                }
            }
            else
            {
                throw new ParserException("This was expected a Identifier or ( in constructor call, Received: [" +
                    parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                    + ", Column: " + parser.CurrenToken.Column);
            }
        }
    }
}