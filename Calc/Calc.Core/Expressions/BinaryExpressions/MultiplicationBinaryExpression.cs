namespace Calc.Core.Expressions.BinaryExpressions
{
    public class MultiplicationBinaryExpression : BinaryExpressionBase
    {
        public MultiplicationBinaryExpression(IExpression left, IExpression right)
            : base(left, right)
        {
            Priority = (int)DeafaultPriorities.DivAndMultilpy;
        }

        public MultiplicationBinaryExpression()
        {
            Priority = (int)DeafaultPriorities.DivAndMultilpy;
        }
        public override double Evaluate()
        {
            return LeftOperand.Evaluate() * RightOperand.Evaluate();
        }
        public override int Priority { get; set; }
    }
}