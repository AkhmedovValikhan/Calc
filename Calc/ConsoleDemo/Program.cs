using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calc.Core;
using Calc.Core.Expressions.Parsers;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();
            var parser = new ExpressionParser();
            bool close = false;
            while (!close)
            {
                Console.WriteLine("Type the expression: ");

                try
                {
                    var expression = Console.ReadLine();
                    var result = calc.Calculate(expression, parser);
                    Console.WriteLine(String.Format("Result: {0}", result));
                }
                catch (Exception e)
                {
                    Console.WriteLine(String.Format("Exception! {0}", e.Message));
                }
                

                Console.WriteLine("Type \"y\" to exit");
                var ans = Console.ReadLine();
                if (ans != null && ans.ToLower().StartsWith("y"))
                {
                    close = true;
                }
            }

        }
    }
}
