namespace Calc.Core.Expressions.BinaryExpressions
{
    public class SubtractionBinaryExpression : BinaryExpressionBase
    {
        public SubtractionBinaryExpression(IExpression left, IExpression right)
            : base(left, right)
        {
            Priority = (int)DeafaultPriorities.SubAndAdd;
        }

        public SubtractionBinaryExpression()
        {
            Priority = (int)DeafaultPriorities.SubAndAdd;
        }

        public override double Evaluate()
        {
            return LeftOperand.Evaluate() - RightOperand.Evaluate();
        }

    }
}