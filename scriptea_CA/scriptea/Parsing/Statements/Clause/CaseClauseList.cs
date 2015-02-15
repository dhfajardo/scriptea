using scriptea.Lexical;
using scriptea.Parsing.Expressions;

namespace scriptea.Parsing.Statements.Clause
{
    public class CaseClauseList:INTerminal
    {
        public void Process(Parser parser)
        {
            if (parser.CurrenToken.Type == TokenType.KwCase)
            {
                new CaseClause().Process(parser);
                this.Process(parser);
            }
            else
            {
                //Epsilon   
            }
        }
    }
}