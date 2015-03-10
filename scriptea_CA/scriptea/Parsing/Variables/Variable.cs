using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Expressions;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Operators.AssignmentOperators;

namespace scriptea.Parsing.Variables
{
    public class Variable:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.Id)
            {
                string _idName = parser.CurrenToken.LexemeVal;
                parser.NextToken();
                var _id = new IdNode {Name = _idName};
                var _result = new Variablep().Process(parser
                    , new SortedDictionary<string, object>(){{"LeftNode",_id}});
                return _result;
            }
            else
            {
                throw new ParserException("This was expected a Identifier, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
        }
    }
}