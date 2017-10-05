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
            string readText = File.ReadAllText(path);//.ToLower();

            string pattern = "(tra)";
            RegexOptions Options = RegexOptions.Compiled | RegexOptions.IgnoreCase;

            //int counter = 0;

            Regex newRegexClass = new Regex(pattern, Options);
            Console.WriteLine("Parsing '{0}' with options {1}:", readText, Options.ToString());
            matches = Options.Matches(readText);

            for (int i = 0; i < matches.Count; i++)
            {
                Console.WriteLine("{0}.{1}", i, matches[i].values);
            }

            Console.ReadLine();
        }

    }
}
