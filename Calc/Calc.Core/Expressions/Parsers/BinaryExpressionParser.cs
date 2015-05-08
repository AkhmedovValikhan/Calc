using System;
using System.Collections.Generic;
using Calc.Core.Expressions.BinaryExpressions;

namespace Calc.Core.Expressions.Parsers
{
    public class BinaryExpressionParser
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
        public IBinaryExpression Parse(char operationCh, IExpression left, IExpression right)
        {
            Type typeOfExpression;
            if (!OperatorsDictionary.TryGetValue(operationCh, out typeOfExpression))
                throw new Exception(String.Format("Операция не найдена: \"{0}\"", operationCh));
            var bin = (IBinaryExpression)Activator.CreateInstance(typeOfExpression, left, right);
            return bin;
        }
    }
}