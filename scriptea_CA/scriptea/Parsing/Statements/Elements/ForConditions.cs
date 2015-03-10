using System.Collections.Generic;
using scriptea.Lexical;
using scriptea.Parsing.Expressions;
using scriptea.Parsing.Variables;
using scriptea.Tree.Expression;
using scriptea.Tree.Statement;

namespace scriptea.Parsing.Statements.Elements
{
    public class ForConditions:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            if (parser.CurrenToken.Type == TokenType.KwVar)
            {
                parser.NextToken();
                var _startEp = (List<ExpressionNode>) new VariableList().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                {
                    parser.NextToken();
                    var _evaluation = (List<ExpressionNode>) new ExpressionOpt().Process(parser, parameters);
                    if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                    {
                        parser.NextToken();
                        var _endEp = (List<ExpressionNode>) new ExpressionOpt().Process(parser, parameters);
                        return new ForNode
                        {
                            StartExpressionNodes = _startEp,
                            EvaluationNodes = _evaluation,
                            EndExpressionNodes = _endEp
                        };
                    }
                    else
                    {
                        throw new ParserException("This was expected ;  Received: [" +
                       parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                       + ", Column: " + parser.CurrenToken.Column);
                    }
                }
                else
                {
                    throw new ParserException("This was expected ; Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
            else
            {
                var _startEp = (List<ExpressionNode>) new ExpressionOpt().Process(parser, parameters);
                if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                {
                    parser.NextToken();
                    var _evaluation = (List<ExpressionNode>) new ExpressionOpt().Process(parser, parameters);
                    if (parser.CurrenToken.Type == TokenType.PmSemicolon)
                    {
                        parser.NextToken();
                        var _endEp = (List<ExpressionNode>) new ExpressionOpt().Process(parser, parameters);
                        return new ForNode
                        {
                            StartExpressionNodes = _startEp,
                            EvaluationNodes = _evaluation,
                            EndExpressionNodes = _endEp
                        };
                    }
                    else
                    {
                        throw new ParserException("This was expected ; Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                    }
                }
                else
                {
                    throw new ParserException("This was expected ; Received: [" +
                   parser.CurrenToken.LexemeVal + "], Row: " + parser.CurrenToken.Row
                   + ", Column: " + parser.CurrenToken.Column);
                }
            }
        }
    }
}
