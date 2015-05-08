namespace Calc.Core.Expressions.BinaryExpressions
{
    public abstract class BinaryExpressionBase : IBinaryExpression
    {

        public IExpression LeftOperand { get; set; }

        public IExpression RightOperand { get; set; }
        public int Priority { get; set; }
        protected BinaryExpressionBase(IExpression left, IExpression right)
        {
            LeftOperand = left;
            RightOperand = right;
        }

        protected BinaryExpressionBase()
        {
            
        }

        public abstract double Evaluate();
    }
}