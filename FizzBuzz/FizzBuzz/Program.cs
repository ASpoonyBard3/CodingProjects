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

                if (i % 15 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("FizzBuzz");
                }

                else if ( i % 7 == 0 && i % 3 == 0 || i % 5 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("FizzBang");
                    if (i % 7 == 0)
                        Console.WriteLine("Bang");
                }
                
                else if (i % 5 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Buzz");
                }

                else if (i % 3 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Fizz");
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(i);
                }

                /*
                else if (i % 13 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Fezz");
                }

                else if (i % 11 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Bong");
                }
                */

            }
            Console.ReadLine();



        }
    }
}
