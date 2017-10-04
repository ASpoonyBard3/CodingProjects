using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = @"C:\SampleText.txt";
            string readText = File.ReadAllText(path).ToLower();


            int counter = 0;

            for (int i = 0; i < readText.Length - 2; i++)
            {
                string maybeTra = readText.Substring(i, 3);
                bool contains = maybeTra.Contains("tra");
                if (contains == true)
                {
                    counter += 1;
                }

            }
            Console.WriteLine(counter);
            Console.ReadLine();
        }

    }
}
