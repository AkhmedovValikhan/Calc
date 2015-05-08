namespace Calc.Core.Expressions.BinaryExpressions
{
    public class SubtractionBinaryExpression : BinaryExpressionBase
    {
        public SubtractionBinaryExpression(IExpression left, IExpression right)
            : base(left, right)
        {
        }

        public override double Evaluate()
        {
            return LeftOperand.Evaluate() - RightOperand.Evaluate();
        }
    }
}