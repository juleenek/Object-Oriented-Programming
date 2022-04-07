using System;
using System.Globalization;
using PudelkoLib;

namespace Pudelko_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            var pudelko = new Pudelko(a: 3, b: 2.39292, c: 3, unit: UnitOfMeasure.centimeter);
            Console.WriteLine(pudelko);

            //double lol = 100.0;
            //Console.WriteLine(decimal.Parse((lol.ToString("F3", CultureInfo.InvariantCulture)).Replace('.', ',')));
        }
    }
}
