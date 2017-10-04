using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListPracticePrime
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> primes = new List<int>
            {
                2,
                3,
                5,
                7,
                11
            };


            foreach (var prime in primes)
                {
                    Console.WriteLine(prime);
                    Console.ReadLine();
                }
        }
    }
}
