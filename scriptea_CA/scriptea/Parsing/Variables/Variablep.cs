using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical;
using scriptea.Parsing.Expressions;
using scriptea.Tree.Expression;
using scriptea.Tree.Expression.Operators.AssignmentOperators;
using scriptea.Tree.Statement;

namespace scriptea.Parsing.Variables
{
    public class Variablep:INTerminal
    {
        public object Process(Parser parser, SortedDictionary<string, object> parameters)
        {
            var _leftNode = (IdNode) parameters["LeftNode"];
            if (parser.CurrenToken.Type == TokenType.OpAssig)
            {
                parser.NextToken();
                var _rightNode =(ExpressionNode)new AssignmentExpression().Process(parser, parameters);
                var _assigNode = new AssigOperatorNode() {LeftNode = _leftNode, RightNode = _rightNode};
                return _assigNode;
            }
            else
            {
                return _leftNode;
            }
        }
    }
}
