using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression;

namespace scriptea.Parsing.Expressions.Constructor
{
    public class ConstructorCall:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                string _idName = parser.CurrenToken.LexemeVal;
                parser.NextToken();
                var _idNode = new IdNode {Name = _idName};
                var _accesor = (Accesor) new ConstructorCallp().Process(parser, parameters);
                _idNode.Accesor = _accesor;
                return _idNode;
            }
            else
            {
                throw new ParserException("This was expected Identifier in constructor call, Received: " + 
                    parser.CurrenToken.LexemeVal + ", Row: " + parser.CurrenToken.Row
                    + ", Column: " + parser.CurrenToken.Column);
            }
        }
    }
}