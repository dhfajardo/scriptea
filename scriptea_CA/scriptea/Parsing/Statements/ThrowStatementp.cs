using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Expressions.Constructor;
using scriptea.Tree.Expression;

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
                var _newConstructor = (ExpressionNode)new ConstructorCall().Process(parser, parameters);
                var _new = new NewNode {ConstructorNode = _newConstructor};
                return _new;
            }
            else
            {
                return null;
            }
        }
    }
}
