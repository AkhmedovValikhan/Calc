namespace Calc.Core.Expressions.BinaryExpressions
{
    public class AdditionBinaryExpression : BinaryExpressionBase
    {
        public AdditionBinaryExpression(IExpression left, IExpression right)
            : base(left, right)
        {
        }

        public override double Evaluate()
        {
            return LeftOperand.Evaluate() + RightOperand.Evaluate();
        }
    }
}