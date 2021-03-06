﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using NLog;
using NLog.Config;
using NLog.Targets;
using Newtonsoft.Json;
using System.Xml;

namespace SupportBank
{

    //class for parsing the name and balance of person objects so that the dictionary can be populated.
    public partial class Person
    {
        public string Name;
        public float Balance;
        public Person(string name, float balance)
        {
            Name = name;
            Balance = balance;
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

                //takes user input and ensures that the file path is correct
                String ImportFile;
                Console.WriteLine("Please supply the filepath to the transaction file");
                ImportFile = (Console.ReadLine());
                string FileExt = Path.GetExtension(ImportFile);
                var fileContents = new List<string>();

                //Console.WriteLine("That's not a valid filepath!");

                //creates a new list object, for entering the list of transactions in the foreach loop 
                List<Transaction> TransactionList = new List<Transaction>();

                if (FileExt == ".csv")
                    fileContents = ParseCSV(ImportFile, TransactionList);

                if (FileExt == ".json")
                    TransactionList = ParseJson(ImportFile);

                if (FileExt == ".xml")
                    TransactionList = ParseXML(ImportFile);

                //this dictionary is populated by the below for each loop
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

            private static List<Transaction> ParseJson(string ImportFile)
            {
                List<Transaction> TransactionList;

                try
                {
                    //load and then convert json file to a .net readable object
                    var JSONdata = File.ReadAllText(ImportFile);
                    TransactionList = JsonConvert.DeserializeObject<List<Transaction>>(JSONdata);
                    logger.Log(LogLevel.Info, "JSON File loaded successfully.");
                    return TransactionList;
                }

                catch (Exception e)
                {
                    logger.Log(LogLevel.Fatal, "The error message was {0}", e.Message);
                    return new List<Transaction>();
                }
            }

            private static List<string> ParseCSV(string ImportFile, List<Transaction> TransactionList)
            {
                List<string> fileContents;
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

                return fileContents;
            }
            private static List<String> ParseXML(string ImportFile, List<Transaction> TransactionList)
            {

                XmlDocument xmlFile = new XmlDocument();
                xmlFile.Load(ImportFile);

                XmlElement DocRoot = xmlFile.DocumentElement;
                XmlNodeList nodes = DocRoot.SelectNodes("/TransactionList/SupportTransaction");

                foreach(XmlNodeList node in nodes)
                {
                    foreach (XmlNodeList childNode in nodes.ChildNodes)
                    {
                        string SupportTransaction = node["SupportTransaction"].InnerText;
                        string Description = node["Description"].InnerText;
                        decimal Value = node["Value"].InnerText;
                        string partiesFrom = node["partiesFrom"].InnerText;
                        string partiesTo = node["PartiesTo"].InnerText;
                    }

                }

                //create an XMLReader
                using (XmlReader reader = XmlReader.Create(new StringReader(xmlFile)))
                {
                    reader.ReadToFollowing("TransactionList");
                    reader.MoveToFirstAttribute();

                    
                }
            }
        }
    }
}
