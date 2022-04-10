using System;
using System.Globalization;
using PudelkoLib;

namespace Pudelko_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // ToString, Pole, Objetosc

            //var pudelko = new Pudelko(a: 1, b: 2, c: 2);
            //Console.WriteLine(pudelko.ToString());
            //Console.WriteLine(pudelko.ToString("cm"));
            //Console.WriteLine(pudelko.Pole);
            //Console.WriteLine(pudelko.Objetosc);

            // Porównywanie pudelek

            //var pudelko1 = new Pudelko(a: 3, b: 1); 
            //var pudelko2 = new Pudelko(a: 3, b: 1); 
            //Console.WriteLine(pudelko1 == pudelko2);
            //Console.WriteLine(pudelko1.Equals(pudelko2));
            //Console.WriteLine(pudelko2.Equals(pudelko1));

            // Dodawanie pudelek

            //var pudelko1 = new Pudelko(a: 53, b: 211, c: 23, UnitOfMeasure.centimeter); // 0,53 | 2,11 | 0,23 
            //var pudelko2 = new Pudelko(a: 312, b: 522, c: 412, UnitOfMeasure.millimeter); // 0,312 | 0,522 | 0,412
            //Console.WriteLine(pudelko1 + pudelko2);

            // Konwersja

            //Pudelko pudelko1 = (30, 133, 292);
            //Console.WriteLine(pudelko1.ToString());

            //var pudelko2 = new Pudelko(32, 11, 5421, UnitOfMeasure.millimeter);
            //double[] arr = (double[])pudelko2;

            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}

            // Indexer

            //var pudelko1 = new Pudelko(a: 3, b: 1);
            //Console.WriteLine(pudelko1[1]);

        }
    }
}
