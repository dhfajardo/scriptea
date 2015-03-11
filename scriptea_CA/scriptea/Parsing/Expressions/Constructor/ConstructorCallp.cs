using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Others;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Operators;

namespace scriptea.Parsing.Expressions.Constructor
{
    public class ConstructorCallp:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            string _typeName = (string) parameters["TypeName"];
            if (parser.CurrenToken.Type == TokenType.PmLeftParent)
            {
                parser.NextToken();
                var _parameters = (List<ExpressionNode>)new ExpressionOpt().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.PmRightParent)
                {
                    parser.NextToken();
                    return new NewNode {Parameters = _parameters, TypeName = _typeName};
                }
                else
                {
                    throw new ParserException("This was expected ) in constructor call, Received: [" + 
                    parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                    + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else if (parser.CurrenToken.Type == TokenType.PmDot)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.Id)
                {
                    string _idName = _typeName + "." + parser.CurrenToken.LexemeVal;
                    parser.NextToken();
                    return this.Process(parser
                        , new SortedDictionary<string, object>() {{"TypeName", _idName}});
                }
                else
                {
                    throw new ParserException("This was expected a Identifier in constructor call, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);

                }
            }
            else
            {
                throw new ParserException("This was expected a Identifier or ( in constructor call, Received: [" +
                    parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                    + ", Column: " + parser.CurrenToken.Column);
            }
        }
    }
}