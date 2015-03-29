using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Parameters;
using scriptea.Parsing.Statements;
using scriptea.Tree.Expression;
using scriptea.Tree.Others;
using scriptea.Tree.Statement;

namespace scriptea.Parsing
{
    public class Element:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwFunction)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.Id)
                {
                    string _idName = parser.CurrenToken.LexemeVal;
                    parser.NextToken();
                    if (parser.CurrenToken.Type == TokenType.PmLeftParent)
                    {
                        parser.NextToken();
                        var _parameters = (List<IdNode>) new ParameterListOpt().Process(parser, parameters);
                        if (parser.CurrenToken.Type == TokenType.PmRightParent)
                        {
                            parser.NextToken();
                            var _statements = (List<StatementNode>) new CompoundStatement().Process(parser, parameters);
                            //var _id = new IdNode {Name = _idName};
                            return new FunctionDeclarationNode {Id = _idName, ParameterList = _parameters, Statements = _statements};
                        }
                        else
                        {
                            throw new ParserException("This was expected ) Received: [" +
                           parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                           + ", Column: " + parser.CurrenToken.Column);
                                }
                    }
                    else
                    {
                        throw new ParserException("This was expected ( Received: [" +
                       parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                       + ", Column: " + parser.CurrenToken.Column);
                        }
                }
                else
                {
                    throw new ParserException("This was expected a Identifier, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else
            {
                return new Statement().Process(parser, parameters);
            }
        }
    }
}
