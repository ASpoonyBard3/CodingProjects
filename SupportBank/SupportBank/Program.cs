using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"C:\Users\SJFow\Desktop\transactions2014.csv";
            var contents = File.ReadAllLines(filePath);



        }
    }

    public class Transaction
    {
        public DateTime Date;
        public string From;
        public string To;
        public string Narrative;
        public float Amount;
        public Transaction(string date, string from, String to, String narrative, string amount)
        {
            Date = DateTime.Parse(date);
            From = from;
            To = to;
            Narrative = narrative;
            Amount = float.Parse(amount);
        } 

    }
}


