using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ThisIsAStringToReverse.");
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            int i = input.Length - 1;
            while (i != -1)
            {
                sb.Append(input[i--]);
            }
            Console.WriteLine("Reversed string is " + sb.ToString());
        }
    }
}
