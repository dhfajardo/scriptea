using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Expressions.Constructor;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Operators;

namespace scriptea.Parsing.Statements
{
    public class ThrowStatementp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                string _idName = parser.CurrenToken.LexemeVal;
                parser.NextToken();
                var _id = new IdNode {Name = _idName};
                return _id;
            }
            else if (parser.CurrenToken.Type == TokenType.KwNew)
            {
                parser.NextToken();
                return new ConstructorCall().Process(parser, parameters);
            }
            else
            {
                return null;
            }
        }
    }
}
