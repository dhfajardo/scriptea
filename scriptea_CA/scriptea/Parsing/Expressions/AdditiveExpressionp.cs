using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Operators;

namespace scriptea.Parsing.Expressions
{
    public class AdditiveExpressionp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.OpSum
                || parser.CurrenToken.Type == TokenType.OpSub)
            {
                new AdditiveOperator().Process(parser, parameters);
                new MultiplicativeExpression().Process(parser, parameters);
                this.Process(parser, parameters);
            }
            else
            {
                //Epsilon
            }
            return null;
        }
    }
}