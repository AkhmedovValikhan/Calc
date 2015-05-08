namespace Calc.Core.Expressions.BinaryExpressions
{
    public class AdditionBinaryExpression : BinaryExpressionBase
    {

        public AdditionBinaryExpression(IExpression left, IExpression right)
            : base(left, right)
        {
            Priority = (int)DeafaultPriorities.SubAndAdd;
        }

        public AdditionBinaryExpression()
        {
            Priority = (int)DeafaultPriorities.SubAndAdd;
        }

        public override double Evaluate()
        {
            return LeftOperand.Evaluate() + RightOperand.Evaluate();
        }
        public override int Priority { get; set; }
    }
}