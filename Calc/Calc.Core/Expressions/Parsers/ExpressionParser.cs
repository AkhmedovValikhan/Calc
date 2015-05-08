﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Calc.Core.Expressions.BinaryExpressions;

namespace Calc.Core.Expressions.Parsers
{
    public class ExpressionParser : IExpressionParser
    {
        public double ParseAndEvaluate(string expression)
        {
            expression = expression.Replace(" ", "");

            var highestPriority = 2; //will be fix
            var operandList = new List<IExpression>();
            var operationList = new List<IBinaryExpression>();
            var nesting = 0;
            if (!AnalyzeBrackets(expression))
                throw new Exception("Unbalanced brackets");
            var i = 0;

            while (i < expression.Length)
            {
                if (Char.IsDigit(expression[i]))
                {
                    operandList.Add(ParseNumber(expression, ref i));
                    continue;
                }
                if (BinaryExpressionParser.ContainsOperation(expression[i]))
                {
                    var operCh = expression[i];
                    var operation = BinaryExpressionParser.Parse(operCh);
                    operation.Priority += nesting;
                    operationList.Add(operation);
                    i++;
                    continue;
                }
                //Увлеичиваем уровень вложенность(nesting), тем самым увеличивая приоритет вложенных выражений
                if (expression[i] == '(')
                {
                    nesting += highestPriority;
                    highestPriority += nesting;
                    i++;
                    continue;
                }
                if (expression[i] == ')')
                {
                    nesting = highestPriority - nesting;
                    i++;
                    continue;
                }
                throw new Exception(String.Format("Operator not found: \"{0}\"", expression[i]));

            }

            
            while (highestPriority > 0)
            {
                var k = 0;

                if (operationList.Count(expr => expr.Priority == highestPriority) == 0)
                {
                    k++;
                    highestPriority--;
                    continue;
                }
               
                while (k < operationList.Count)
                {
                    if (operationList[k].Priority == highestPriority)
                    {
                        var binExp = operationList[k];
                        binExp.LeftOperand = operandList[k];
                        binExp.RightOperand = operandList[k + 1];
                        operandList[k] = binExp;
                        operationList.RemoveAt(k);
                        operandList.RemoveAt(k + 1);
                    }
                    else k++;
                }
                highestPriority--;
            }

            var totalResult = operandList.Single().Evaluate();
            return totalResult;

        }

        public bool AnalyzeBrackets(string expression)
        {
            var bracketsBalance = 0;
            foreach (var ch in expression)
            {
                if (ch == '(')
                {
                    bracketsBalance ++;
                    continue;
                }
                if (ch == ')')
                {
                    bracketsBalance--;
                }
            }

            return bracketsBalance == 0;
        }

        public IExpression ParseNumber(string expr, ref int index)
        {
            var result = new StringBuilder();
            while (index < expr.Length && (expr[index] == ',' || Char.IsDigit(expr[index])))
            {
                result.Append(expr[index++]);
            }
            return new NumberExpression(result.ToString());
        }
    }
}
