using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Operators;

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
                var _newNode = (NewNode) new ConstructorCallp().Process(parser
                    , new SortedDictionary<string, object>() {{"TypeName", _idName}});
                return _newNode;
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