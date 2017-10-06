using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingPractice
{
    class Program
    {
        static void Main(string[] args)
        {
              MyLoggingClass NewLogger = new MyLoggingClass Class();
              
        }
    }
    public class MyLoggingClass
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void MyMethod1()
        {
            logger.Trace("Sample trace message.");
            logger.Debug("Sample debug message");
            logger.Info("Sample information message.");
            logger.Warn("Sample warning message");
            logger.Error("Sample error messaage");
            logger.Fatal("Sample fatal error message");

            //alternatively you can call the Log() method
            //and pass the log level as the parameter.
            logger.Log(LogLevel.Info, "Sample information message");
        }
    }
}
