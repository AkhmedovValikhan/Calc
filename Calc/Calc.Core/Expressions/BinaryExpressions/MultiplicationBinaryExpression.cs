namespace Calc.Core.Expressions.BinaryExpressions
{
    public class MultiplicationBinaryExpression : BinaryExpressionBase
    {
        public MultiplicationBinaryExpression(IExpression left, IExpression right)
            : base(left, right)
        {
        }

        public override double Evaluate()
        {
            return LeftOperand.Evaluate() * RightOperand.Evaluate();
        }
    }
}