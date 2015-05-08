using System;
using System.Collections.Generic;
using Calc.Core.Expressions.BinaryExpressions;

namespace Calc.Core.Expressions.Parsers
{
    public static class BinaryExpressionParser
    {
        public static IDictionary<char, Type> OperatorsDictionary
        {
            get
            {
                return new Dictionary<char, Type>
                {
                    {'+', typeof (AdditionBinaryExpression)},
                    {'-', typeof (SubtractionBinaryExpression)},
                    {'/', typeof (DivisionBinaryExpression)},
                    {'*', typeof (MultiplicationBinaryExpression)}
                };
            }
        }

        public static bool ContainsOperation(char ch)
        {
            return OperatorsDictionary.ContainsKey(ch);
        }
        public static IBinaryExpression Parse(char operationCh)
        {
            Type typeOfExpression;
            if (!OperatorsDictionary.TryGetValue(operationCh, out typeOfExpression))
                throw new Exception(String.Format("Operator not found: \"{0}\"", operationCh));
            var bin = (IBinaryExpression)Activator.CreateInstance(typeOfExpression);
            return bin;
        }
    }
}