using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWorkingClassExample
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCarClass MyCar1 = new MyCarClass(4, 2015, true, "Toyota");
            MyCarClass MyCar2 = new MyCarClass(5, 2020, true, "Ferreri");
            MyCarClass MyCar3 = new MyCarClass(6, 2016, false, "LandRover");

            Console.WriteLine("A my first car had {0} tyres, was made in the year {1}, it didn't usually run {2} and it was the make {3}.", MyCar1.NumTires, MyCar1.Year, MyCar1.Runs, MyCar1.Make);
            Console.WriteLine("A my first car had {0} tyres, was made in the year {1}, it didn't usually run {2} and it was the make {3}.", MyCar2.NumTires, MyCar2.Year, MyCar2.Runs, MyCar2.Make);
            Console.WriteLine("A my first car had {0} tyres, was made in the year {1}, it didn't usually run {2} and it was the make {3}.", MyCar3.NumTires, MyCar3.Year, MyCar3.Runs, MyCar3.Make);
            Console.ReadLine();
        }
    }
    class MyCarClass
    {
        public int NumTires;
        public int Year;
        public bool Runs;
        public string Make;
        public MyCarClass(int numTires, int year, bool runs, string make)
        {
            NumTires = numTires+1;
            Year = year+100;
            Runs = runs;
            Make = make;
        }
        
    }
}
