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
            List<string> contents = File.ReadAllLines(filePath).ToList();

            List<Transaction> TransactionList = new List<Transaction>();

            foreach (var line in contents.GetRange(1, contents.Count - 1))
            {
                string [] splitLine = line.Split(',');
                Transaction transaction = new Transaction(splitLine[0],splitLine[1],splitLine[2],splitLine[3],splitLine[4]);
                TransactionList.Add(transaction);
            }

            foreach (var transaction in TransactionList)
            {
                
                
                //Console.WriteLine(transaction.From);
            }

            Console.ReadLine();
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
    public class Person
    {
        public string Name;
        public float Balance;
        public Person(string name, string balance)
        {
            Name = name;
            Balance = float.Parse(balance);
        }
    }
}


