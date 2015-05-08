using System;

namespace Calc.Core.Expressions
{
    public class NumberExpression : IExpression
    {
        public string Number { get; set; }

        public NumberExpression(string number)
        {
            Number = number;
        }

        public double Evaluate()
        {
            return Double.Parse(Number);
        }
    }
}