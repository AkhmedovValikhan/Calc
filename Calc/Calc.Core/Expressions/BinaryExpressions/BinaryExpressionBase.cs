namespace Calc.Core.Expressions.BinaryExpressions
{
    public abstract class BinaryExpressionBase : IBinaryExpression
    {

        public IExpression LeftOperand { get; set; }

        public IExpression RightOperand { get; set; }

        protected BinaryExpressionBase(IExpression left, IExpression right)
        {
            LeftOperand = left;
            RightOperand = right;
        }

        public abstract double Evaluate();
    }
}