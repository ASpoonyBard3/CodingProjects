using System;
using NLog;

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
}
