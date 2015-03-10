using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Expression;
using scriptea.Tree.Others;
using scriptea.Tree.Statement;

namespace scriptea.Parsing.Statements.Blocks
{
    public class CatchBlock:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwCatch)
            {
                parser.NextToken();
                if (parser.CurrenToken.Type == TokenType.PmLeftParent)
                {
                    parser.NextToken();
                    if (parser.CurrenToken.Type == TokenType.Id)
                    {
                        string _idName = parser.CurrenToken.LexemeVal;
                        parser.NextToken();
                        if (parser.CurrenToken.Type == TokenType.PmRightParent)
                        {
                            parser.NextToken();
                            var _codeCatch = (List<StatementNode>) new CompoundStatement().Process(parser, parameters);
                            var _id = new IdNode {Name = _idName};
                            var _catch = new CatchNode {Id = _id, CodeCatch = _codeCatch};
                            var _try = new TryNode {ExceptionID = _id, CatchBlockCode = _catch};
                            return _try;
                        }
                        else
                        {
                            throw new ParserException("This was expected ) in the catch block, Received: [" +
                           parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                           + ", Column: " + parser.CurrenToken.Column);
                        }
                    }
                    else
                    {
                        throw  new ParserException("This was expected a Identifier in the catch block, Received: [" +
                           parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                           + ", Column: " + parser.CurrenToken.Column);
                    }
                }
                else
                {
                    throw new ParserException("This was expected ( in the catch block, Received: [" +
                       parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                       + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else
            {
                return new TryNode();
            }
        }
    }
}
