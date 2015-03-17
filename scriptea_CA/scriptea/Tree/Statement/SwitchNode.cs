using scriptea.Tree.Expression;
using scriptea.Tree.Others;

namespace scriptea.Tree.Statement
{
    public class SwitchNode:StatementNode
    {
        public ExpressionNode EvaluationNode { get; set; }
        public BaseCaseNode /*CaseNode*/ CaseBlockNode { get; set; }
        public override void Interpret(SymbolTable table)
        {
            var _evaluation = EvaluationNode.Evaluate(table);
            bool _result = InterpreterCase(CaseBlockNode, EvaluationNode, table, "case");
            if (!_result)
            {
                _result = InterpreterCase(CaseBlockNode, EvaluationNode, table, "defauld");
            }

        }

        private bool InterpreterCase(BaseCaseNode _case, ExpressionNode evaluationSwitch, SymbolTable table, string flag)
        {
            if (flag == "case")
            {
                if (_case is CaseNode)
                {
                    if (((CaseNode)_case).EvaluationNode.Evaluate(table) == evaluationSwitch.Evaluate(table))
                    {
                        try
                        {
                            foreach (var statementNode in ((CaseNode)_case).CodeNode)
                            {
                                statementNode.Interpret(table);
                            }
                        }
                        catch (BreakException)
                        {
                            
                        }
                        return true;
                    }
                    else
                    {
                        return InterpreterCase(_case.NextCase, evaluationSwitch, table, "case");
                    }
                }
                else if(_case is DefauldNode)
                {
                    return InterpreterCase(_case.NextCase, evaluationSwitch, table, "case");
                }
                else
                {
                    return false;
                }
            }
            else if (flag == "defauld")
            {
                if (!(_case is DefauldNode))
                {
                    return InterpreterCase(_case.NextCase, evaluationSwitch, table, "defauld");
                }
                else
                {
                    try
                    {

                        foreach (var statementNode in ((DefauldNode)_case).CodeNode)
                        {
                            statementNode.Interpret(table);
                        }
                    }
                    catch (BreakException)
                    {

                    }
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}