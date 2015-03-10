using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;
using scriptea.Tree.Expression.Operators.UnaryOperators;

namespace scriptea.Parsing.Operators
{
    public class DecrementOperator:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _flag = (string)parameters["Flag"];
            if (parser.CurrenToken.Type == TokenType.OpDec)
            {
                parser.NextToken();
                if (_flag == "Pre")
                {
                    return new DecPreOperatorNode();
                }
                else
                {
                    return new DecPosOperatorNode();
                }
            }
            else
            {
                throw new ParserException("This was expected --, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
        }
    }
}
