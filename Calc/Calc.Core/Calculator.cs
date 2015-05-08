using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calc.Core.Expressions.Parsers;

namespace Calc.Core
{
    public class Calculator
    {
        public double Calculate(string exp, IExpressionParser parser)
        {
            var result = parser.ParseAndEvaluate(exp);
            return result;
        }
    }
}
