using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Calc.Core.Expressions.BinaryExpressions;

namespace Calc.Core.Expressions.Parsers
{
    public class ExpressionParser : IExpressionParser
    {
        public double ParseAndEvaluate(string expression)
        {
            expression = expression.Trim();
            var operationStack = new Stack<IBinaryExpression>();
            var resultsQueue = new Queue<IExpression>();
            if (!AnalyzeBrackets(expression))
                throw new Exception("Нарушен баланс скобок");
            var i = 0;
            while (i < expression.Length)
            {
                if (Char.IsDigit(expression[i]))
                {
                    resultsQueue.Enqueue(ParseNumber(expression, ref i));
                    continue;
                }
                if (BinaryExpressionParser.ContainsOperation(expression[i]))
                {
                    var operCh = expression[i];
                    if (Char.IsDigit(expression[i + 1]))
                    {
                        i += 1;
                        resultsQueue.Enqueue(ParseNumber(expression, ref i));
                    }
                    else 
                        throw new NotImplementedException();

                    var result = BinaryExpressionParser.Parse(operCh, resultsQueue.Dequeue(),
                        resultsQueue.Dequeue());
                    resultsQueue.Enqueue(result);
                    continue;
                }
                if (expression[i] == '(')
                {
                    throw new NotImplementedException();
                    continue;
                }
                if (expression[i] == ')')
                {
                    throw new NotImplementedException();
                    continue;
                }
                throw new Exception("Неопознаный оператор" + expression[i]);

            }
            var totalResult = resultsQueue.Dequeue().Evaluate();
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
