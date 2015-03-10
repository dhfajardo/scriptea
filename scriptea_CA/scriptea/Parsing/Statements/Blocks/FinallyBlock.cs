using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Tree.Others;
using scriptea.Tree.Statement;

namespace scriptea.Parsing.Statements.Blocks
{
    public class FinallyBlock:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwFinally)
            {
                parser.NextToken();
                var _finallyCode = (List<StatementNode>) new CompoundStatement().Process(parser, parameters);
                return new FinallyNode {FinallyCode = _finallyCode};
            }
            else
            {
                return new FinallyNode();
            }
        }
    }
}