namespace Calc.Core.Expressions.Parsers
{
    public interface IExpressionParser
    {
        double ParseAndEvaluate(string expression);
    }
}