using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Calc.Core.Expressions.BinaryExpressions;

namespace Calc.Core.Expressions
{
    public class ExpressionFactory
    {

        public IDictionary<string, Type> BinaryExpressionsOperatorsDictionary { get; private set; }

        public ExpressionFactory()
        {
            BinaryExpressionsOperatorsDictionary = new Dictionary<string, Type>();
        }

        public void RegisterBinaryExpression(string operatorString, Type typeOfExpression)
        {
            if (ContainsOperation(operatorString))
             throw new Exception("Operator already registered");

            BinaryExpressionsOperatorsDictionary.Add(operatorString, typeOfExpression);
        }

        public bool ContainsOperation(string ch)
        {
            return BinaryExpressionsOperatorsDictionary.ContainsKey(ch);
        }

        public IBinaryExpression GetBinary(string op)
        {
            if(!ContainsOperation(op))
                throw new Exception(String.Format("Operator \"{0}\" not registered", op));

            Type typeOfExpression = BinaryExpressionsOperatorsDictionary[op];

            var bin = (IBinaryExpression) Activator.CreateInstance(typeOfExpression);
            return bin;
        }

        public IExpression GetNumber(string num)
        {
            return new NumberExpression(num);
        }
    }
}
