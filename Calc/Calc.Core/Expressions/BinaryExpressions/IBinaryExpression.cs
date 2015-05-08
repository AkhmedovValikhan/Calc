namespace Calc.Core.Expressions.BinaryExpressions
{
    public interface IBinaryExpression : IExpression
    {
        IExpression LeftOperand { get; set; }
        IExpression RightOperand { get; set; }
    }
}