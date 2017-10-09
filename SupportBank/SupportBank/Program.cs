using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using NLog;
using NLog.Config;
using NLog.Targets;
using Newtonsoft.Json;

namespace SupportBank
{
    // class for parsing the individual elements of the spreadsheet into the correct data types so that they can be split into a list format. 
    public class Transaction
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public DateTime Date;
        public string FromAccount;
        public string ToAccount;
        public string Narrative;
        public float Amount;
        public Transaction(string date, string from, String to, String narrative, string amount)
        {
            Date = DateTime.Parse(date);
            FromAccount = from;
            ToAccount = to;
            Narrative = narrative;
            Amount = float.Parse(amount);
        }
    }

    //class for parsing the name and balance of person objects so that the dictionary can be populated.
    public class Person
    {
        public string Name;
        public float Balance;
        public Person(string name, float balance)
        {
            Name = name;
            Balance = balance;
        }

        //takes in a csv file for parsing and converts the contents of the file into a string list
        public class CsvParse { }

        public class XmlParser
        {
            /*
            if (FileExt == ".xml")
                {
                    //load and then convert json file to a .net readable object
                    XmlReader xmlContent = XmlReader.Create(@"C:\Users\SJFow\Documents\CodingProjects\Transactions2012.xml");
                    while (xmlContent.Read())
                    {
                        if ((xmlContent.NodeType == XmlNodeType.Element) && (xmlContent.Name == "TransactionList"))
                        {
                            if (xmlContent.HasAttributes)
                                Console.WriteLine(xmlContent.GetAttribute("Description"));
                                    + xmlContent.GetAttribute("Value") + ": "
                                    + xmlContent.GetAttribute("Parties") + ": "
                                    + xmlContent.GetAttribute("Parties") + ("From") +("To")
                        }
                    }
                    logger.Log(LogLevel.Info, "XML File loaded successfully.");
                }
                */
        }

        class Program
        {
            private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

            static void Main(string[] args)
            {
                var config = new LoggingConfiguration();
                var target = new FileTarget { FileName = @"C:\Users\SJFow\Documents\Logs\$(get-date yyyy.M.dd.hh.mm.ss)SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
                config.AddTarget("File Logger", target);
                config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
                LogManager.Configuration = config;


                String ImportFile;
                Console.WriteLine("Please supply the filepath to the transaction file");
                ImportFile = (Console.ReadLine());

                string FileExt = Path.GetExtension(ImportFile);
                var fileContents = new List<string>();
                //var JSOn
                List<Transaction> TransactionList = new List<Transaction>();


                if (FileExt == ".csv")
                {
                    //takes in a csv file for parsing and converts the contents of the file into a string list
                    fileContents = File.ReadAllLines(ImportFile).ToList();
                    logger.Log(LogLevel.Info, "CSV File loaded successfully.");
                    foreach (var line in fileContents.GetRange(1, fileContents.Count - 1))
                    {
                        string[] splitLine = line.Split(',');

                        try
                        {
                            Transaction transaction = new Transaction(splitLine[0], splitLine[1], splitLine[2], splitLine[3], splitLine[4]);
                            TransactionList.Add(transaction);
                        }
                        catch (Exception e)
                        {
                            logger.Log(LogLevel.Fatal, "The date here {0},{1},{2},{3},{4},", splitLine[0], splitLine[1], splitLine[2], splitLine[3], splitLine[4]);
                            logger.Log(LogLevel.Fatal, "The error message was {0}", e.Message);
                        };

                    }
                }

                if (FileExt == ".json")
                {
                    //load and then convert json file to a .net readable object
                    var JSONdata = File.ReadAllText(ImportFile);
                    TransactionList = JsonConvert.DeserializeObject<List<Transaction>>(JSONdata);
                    logger.Log(LogLevel.Info, "JSON File loaded successfully.");
                }
                /*
                            //return list of every transaction, with the date and narrative for the account with that name.
                            foreach (var line in fileContents)
                            {
                                Console.WriteLine(line);
                            }
                            Console.ReadLine();
                            */

                //creates a new list object, for entering the list of transactions in the foreach loop 
                //for spliting into individual elements


                //counts through the content of the content list string split across the elements of the transaction class, 
                //entering the elements 
                //into a list


                //this dictionary is populated by the below for each loop
                //with call to the person class which takes the person as string type and the balance amount as a float 

                Dictionary<String, Person> PersonalTransactions = new Dictionary<String, Person>();

                foreach (var transaction in TransactionList)
                {
                    //instantiates two new person classes, then the if statement populates the personal transaction dictionary
                    //with the person name(if they don't exist already as a key) if they do exists it updates the transaction amount which is
                    //stored as the dictionary value
                    Person FromPerson = new Person(transaction.FromAccount, -transaction.Amount);
                    Person ToPerson = new Person(transaction.ToAccount, transaction.Amount);

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
}
