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

            for (int i = 1; i < 71; i++)
            {
                string result = System.String.Empty;

                if (i % 3 == 0)
                {
                    result = "Fizz";
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }

                if (i % 5 == 0)
                {
                    result = result + "Buzz";
                }

                if (i % 7 == 0)
                {
                    result = result + "Bang";
                    Console.ForegroundColor = ConsoleColor.Blue;
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
