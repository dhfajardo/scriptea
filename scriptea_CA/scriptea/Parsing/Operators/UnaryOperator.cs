using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;
using scriptea.Tree.Expression.Operators.UnaryOperators;

namespace scriptea.Parsing.Operators
{
    public class UnaryOperator:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpNotBit)
            {
                parser.NextToken();
                return new NotBitOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpNot)
            {
                parser.NextToken();
                return new NotOperatorNode();
            }
            else if (parser.CurrenToken.Type == TokenType.OpSub)
            {
                parser.NextToken();
                return new NegativeOperatorNode();
            }
            else
            {
                throw new ParserException("This was expected !,~ or -, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
            return null;
        }
    }
}
