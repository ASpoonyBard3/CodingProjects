using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPractice
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Employee
    {
        private int _Age;
        private string _Name;

        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public void GetPayCheck()
        {

        }

        public void Work()
        {

        }
    }

    public class Sample
    {
        public static void Maih()
        {
            Employee marissa = new Employee();

            marissa.Work();
            marissa.GetPayCheck();
        }
    }
}
