using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;
using scriptea.Parsing.Expressions;
using scriptea.Tree.Expression;
using scriptea.Tree.Others;
using scriptea.Tree.Statement;

namespace scriptea.Parsing.Statements.Clause
{
    public class CaseClause:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwCase)
            {
                parser.NextToken();
                var _evaluation = (ExpressionNode) new AssignmentExpression().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.PmColon)
                {
                    parser.NextToken();
                    var _case = new CaseNode {EvaluationNode = _evaluation};
                    var _caseCode = (List<StatementNode>) new StatementList().Process(parser, parameters);
                    _case.CodeNode = _caseCode;
                    return _case;
                }
                else
                {
                    throw new ParserException("This was expected : in the case clause, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else
            {
                throw new ParserException("This was expected the tokent: case, Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
            }
        }
    }
}
