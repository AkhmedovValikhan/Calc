using System.Security.Cryptography.X509Certificates;

namespace Calc.Core.Expressions
{
    public interface IExpression
    {
        int Priority { get; set; }
        double Evaluate();
    }
}