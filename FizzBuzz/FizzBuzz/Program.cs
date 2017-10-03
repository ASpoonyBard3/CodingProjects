using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 1; i < 144; i++)
            {
                string result = System.String.Empty;

                if (i % 3 == 0)
                {
                    result = "Fizz";
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                if (i % 5 == 0)
                {
                    result = result + "Buzz";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                if (i % 7 == 0)
                {
                    result = result + "Bang";
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                if (i % 11 == 0)
                {
                    result = "Bong";
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                if (i % 13 == 0)
                {
                    if (result.StartsWith("B") || result.StartsWith("b"))
                    {
                        result = "Fezz" + result;
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                        result = "Fezz";

                }

                if (result == System.String.Empty)
                {
                    Console.WriteLine(i);

                }
                else
                    Console.WriteLine(result);
                    
            }
            Console.ReadLine();
        }
    }
}
