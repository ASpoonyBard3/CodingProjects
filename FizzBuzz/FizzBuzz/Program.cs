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
            Console.WriteLine("How high do you want to fizzbuzz?");
            int Max = Convert.ToInt32(Console.ReadLine());


            for (int i = 1; i < Max; i++)
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
                    if (result.StartsWith("B"))
                    {
                        result = "Fezz" + result;
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                        result = "Fezz";
                }
                if (i % 17 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    //result = String
                    
                        
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
