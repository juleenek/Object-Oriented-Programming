using System;
using PudelkoLib;

namespace Pudelko_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            var pudelko = new Pudelko(10000, 101, 101, UnitOfMeasure.millimeter);
            Console.WriteLine(pudelko);
        }
    }
}
