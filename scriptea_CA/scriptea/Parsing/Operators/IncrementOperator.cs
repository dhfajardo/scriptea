using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression.Operators.UnaryOperators;

namespace scriptea.Parsing.Operators
{
    public class IncrementOperator:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _flag = (string)parameters["Flag"];
            if (parser.CurrenToken.Type == TokenType.OpInc)
            {
                parser.NextToken();
                if (_flag == "Pre")
                {
                    return new IncPreOperatorNode();
                }
                else
                {
                    return new IncPosOperatorNode();
                }
            }
            else
            {
                throw new LexerException("This was expected ++, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
        }
    }
}