using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;
using scriptea.Parsing.Others;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Expressions
{
    public class MemberExpression:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                string _value = parser.CurrenToken.LexemeVal;
                parser.NextToken();
                var _accesor = (Accesor) new AccesorList().Process(parser,null);
                if (_accesor is FunctionAccesor)
                {
                    var _function = (FunctionAccesor) _accesor;
                    if (_function.Name == "")
                    {
                        return new FunctionNode {Name = _value, Accesor = _accesor};
                    }
                }
                return new IdNode{Name = _value, Accesor = _accesor};
            }
            else
            {
                throw new ParserException("This was expected a Identifier in member expression, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
        }
    }
}
