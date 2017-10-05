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
            String path = @"C:\Users\SJFow\Documents\CodingProjects\SampleText.txt";
            string readText = File.ReadAllText(path);//.ToLower();

            var pattern = "(tra)";
            RegexOptions Options = RegexOptions.Compiled | RegexOptions.IgnoreCase;


            Regex newRegexClass = new Regex(pattern, Options);
            var matches = newRegexClass.Matches(readText);
            foreach (Match match in matches)
            {

            }
            for (int i = 0; i < matches.Count; i++)
            {
                Match match = matches[i];
                Console.WriteLine("{0}.{1}", i, matches[i].Value);
            }

            Console.ReadLine();
        }

    }
}
