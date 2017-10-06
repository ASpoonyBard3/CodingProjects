using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = @"C:\Users\SJFow\Documents\Logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;


            //takes in the files for parsing and converts the contents of the file into a string list
            var filePath = @"C: \Users\SJFow\Desktop\DodgyTransaction2015.csv";

            List<string> contents = File.ReadAllLines(filePath).ToList();

            //return list of every transaction, with the date and narrative for the account with that name.
            foreach (var line in contents)
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();

            //creates a new list object, for entering the list of transactions in the foreach loop 
            //for spliting into individual elements
            List<Transaction> TransactionList = new List<Transaction>();

            //why does this for loop exist? counts through the content of the content list, 
            //using the range to stop before it reaches the end of the string list and breaks the code
            //the string is then split across the elements of the transaction class, entering the elements 
            //into a list
            foreach (var line in contents.GetRange(1, contents.Count - 1))
            {
                string[] splitLine = line.Split(',');
                Transaction transaction = new Transaction(splitLine[0], splitLine[1], splitLine[2], splitLine[3], splitLine[4]);
                TransactionList.Add(transaction);
            }

            /*this dictionary is populated by the below for each loop
            with call to the person class which takes the person as string type and the balance amount as a float 
            */
            Dictionary<String, Person> PersonalTransactions = new Dictionary<String, Person>();

            foreach (var transaction in TransactionList)
            {
                //instantiates two new person classes, then the if statement populates the personal transaction dictionary
                //with the person name(if they don't exist already as a key) if they do exists it updates the transaction amount which is
                //stored as the dictionary value
                Person FromPerson = new Person(transaction.From, -transaction.Amount);
                Person ToPerson = new Person(transaction.To, transaction.Amount);

                //use FromPerson class to populate subtracts from the person's balance. 
                if (PersonalTransactions.ContainsKey(FromPerson.Name))
                {
                    PersonalTransactions[FromPerson.Name].Balance -= transaction.Amount;
                }
                else
                {
                    PersonalTransactions.Add(FromPerson.Name, FromPerson);
                }

                //use ToPerson class to populate additions to the person's balance. 
                if (PersonalTransactions.ContainsKey(ToPerson.Name))
                {
                    PersonalTransactions[ToPerson.Name].Balance += transaction.Amount;
                }
                else
                {
                    PersonalTransactions.Add(ToPerson.Name, ToPerson);
                }
            }

            Console.WriteLine("Do you want to see the summary of transactions? Yes/No");
            String UserInput = Console.ReadLine();

            if (UserInput == "Yes")
                //reads in the the personal transaction class by each person key and writes the output to the console.
                foreach (var person in PersonalTransactions)
                {
                    Console.WriteLine("{0} account balance is {1}.", person.Key, person.Value.Balance);
                }
            else
                Console.WriteLine("Goodbye.");
            Console.ReadLine();
            }
        }
    }

    // class for parsing the individual elements of the spreadsheet into the correct data types so that they can be split into a list format. 
    public class Transaction
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
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

    } //class for parsing the name and balance of person objects so that the dictionary can be populated.
    public class Person
    {
        public string Name;
        public float Balance;
        public Person(string name, float balance)
        {
            Name = name;
            Balance = balance;
        }
    }
     