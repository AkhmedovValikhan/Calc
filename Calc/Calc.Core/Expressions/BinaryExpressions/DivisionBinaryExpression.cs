namespace Calc.Core.Expressions.BinaryExpressions
{
    public class DivisionBinaryExpression : BinaryExpressionBase
    {
        public DivisionBinaryExpression(IExpression left, IExpression right)
            : base(left, right)
        {
            Priority = (int)DeafaultPriorities.DivAndMultilpy;
        }

        public DivisionBinaryExpression()
        {
            Priority = (int)DeafaultPriorities.DivAndMultilpy;
        }

        public override double Evaluate()
        {
            return LeftOperand.Evaluate() / RightOperand.Evaluate();
        }
    }
}