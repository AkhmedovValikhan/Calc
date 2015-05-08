namespace Calc.Core.Expressions.BinaryExpressions
{
    public class DivisionBinaryExpression : BinaryExpressionBase
    {
        public static short Precence = 2;
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
        public override int Priority { get; set; }
    }
}