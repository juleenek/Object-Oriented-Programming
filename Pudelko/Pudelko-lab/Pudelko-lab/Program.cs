using System;
using System.Globalization;
using PudelkoLib;

namespace Pudelko_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            var pudelko = new Pudelko(a: 2.5, b: 9.321, c: 0.1);

            Console.WriteLine(pudelko.ToString("cm"));

        }
    }
}
