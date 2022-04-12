using System;
using System.Collections.Generic;
using System.Globalization;
using PudelkoLib;

namespace Pudelko_lab
{
    static class Program
    {
        public static Pudelko Kompresuj(this Pudelko pudelko)
        {
            double V = pudelko.Objetosc;
            double cubeEdge = Math.Pow(V, (1 / 3D)); 
            return new Pudelko(cubeEdge, cubeEdge, cubeEdge);
        }
        // https://docs.microsoft.com/pl-pl/dotnet/api/system.comparison-1?view=net-6.0
        // https://www.geeksforgeeks.org/how-to-sort-a-list-in-c-sharp-list-sort-method-set-2/
        private static int SortowaniePudelek(Pudelko p1, Pudelko p2)
        {
            if (p1.Objetosc < p2.Objetosc) return -1;
            if (p1.Objetosc > p2.Objetosc) return 1;
            if (p1.Objetosc == p2.Objetosc)
            {
                if (p1.Pole < p2.Pole) return -1;
                if (p1.Pole > p2.Pole) return 1;
                if (p1.Pole == p2.Pole)
                {
                    if ((double)(p1.A + p1.B + p1.C) < (double)(p2.A + p2.B + p2.C)) return -1;
                    if ((double)(p1.A + p1.B + p1.C) > (double)(p2.A + p2.B + p2.C)) return 1;
                }
            }
            return 0;
        }
        private static void Display(List<Pudelko> list)
        {
            foreach (var pudelko in list)
            {
                Console.WriteLine(pudelko);

                // SPRAWDZENIE
                //Console.WriteLine($"Objetosc: {pudelko.Objetosc} Pole: {pudelko.Pole} Dlugosci: {pudelko.A + pudelko.B + pudelko.C}");
            }
        }
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

            // Iterator

            //var pudelko1 = new Pudelko(a: 3, b: 1);
            //Pudelko pudelko2 = (30, 133, 292);

            //foreach (var item in pudelko1)
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var item in pudelko2)
            //{
            //    Console.WriteLine(item);
            //}

            // Parse

            //Pudelko P1 = Pudelko.Parse("2.500 cm × 9.321 cm × 0.100 cm");
            //Pudelko P2 = new Pudelko(2.5, 9.321, 0.1);
            //Console.WriteLine(P1);
            //Console.WriteLine(P2);
            //Console.WriteLine(P1 == P2);

            // Kompresuj

            //var pudelko = new Pudelko(a: 6, b: 3, c: 4);
            //Console.WriteLine(Kompresuj(pudelko));

            //// Sortowanie pudelek

            //var pudelko = new Pudelko(3000, 3000, 3000, UnitOfMeasure.millimeter);
            //Console.WriteLine($"{pudelko.ToString()}  Pole: {pudelko.Pole},  Objetosc: {pudelko.Objetosc},  Dodanie: {pudelko.A + pudelko.B + pudelko.C}");

            List<Pudelko> pudelka = new List<Pudelko>();
            pudelka.Add(new Pudelko(1, 1, 1)); // 0 --- 1.000 m × 1.000 m × 1.000 m  Pole: 6,  Objetosc: 1,  Dodanie: 3
            pudelka.Add(new Pudelko(a: 10, b: 10, c: 10)); // 1 --- 10.000 m × 10.000 m × 10.000 m  Pole: 600,  Objetosc: 1000,  Dodanie: 30
            pudelka.Add(new Pudelko(a: 1.33325325543, b: 3.45235, c: 2.523354)); // 2 --- 1.333 m × 3.452 m × 2.523 m  Pole: 33,357256,  Objetosc: 11,61463731,  Dodanie: 7,308

            // Te same Objetosci
            pudelka.Add(new Pudelko(1, 2, 3)); // 3 --- 1.000 m × 2.000 m × 3.000 m Pole: 22,  Objetosc: 6,  Dodanie: 6
            pudelka.Add(new Pudelko(a: 600, b: 100, c: 100, unit: UnitOfMeasure.centimeter)); // 4 --- 6.000 m × 1.000 m × 1.000 m  Pole: 26,  Objetosc: 6,  Dodanie: 8

            // Te same Objetosci
            pudelka.Add(new Pudelko(a: 3.000000, b: 2.00000, c: 4.000000, unit: UnitOfMeasure.meter)); // 5 --- 3.000 m × 2.000 m × 4.000 m  Pole: 52,  Objetosc: 24,  Dodanie: 9
            pudelka.Add(new Pudelko(8000, 3000, 1000, UnitOfMeasure.millimeter)); // 6 --- 8.000 m × 3.000 m × 1.000 m  Pole: 70,  Objetosc: 24,  Dodanie: 12
            pudelka.Add(new Pudelko(a: 200, b: 200, c: 600, unit: UnitOfMeasure.centimeter)); // 7 --- 2.000 m × 2.000 m × 6.000 m  Pole: 56,  Objetosc: 24,  Dodanie: 10      
            
            pudelka.Add(new Pudelko()); // 8 --- 0.100 m × 0.100 m × 0.100 m  Pole: 0,06,  Objetosc: 0,001,  Dodanie: 0,30000000000000004
            pudelka.Add((Pudelko)(30, 133, 292)); // 9 --- 0.030 m × 0.133 m × 0.292 m  Pole: 0,103172,  Objetosc: 0,00116508,  Dodanie: 0,45499999999999996
            pudelka.Add(new Pudelko(b: 4, a: 5)); // 10 --- 5.000 m × 4.000 m × 0.100 m  Pole: 41,8,  Objetosc: 2,  Dodanie: 9,1
            pudelka.Add(Pudelko.Parse("244 cm × 903 cm × 231 cm")); // 11 --- 2.440 m × 9.030 m × 2.310 m  Pole: 97,0578,  Objetosc: 50,896692,  Dodanie: 13,78


            pudelka.Add(new Pudelko(a: 300, b: 300, c: 300, unit: UnitOfMeasure.centimeter)); // 12 --- 3.000 m × 3.000 m × 3.000 m  Pole: 54,  Objetosc: 27,  Dodanie: 9
            pudelka.Add(new Pudelko(3000, 3000, 3000, UnitOfMeasure.millimeter)); // 13 --- 3.000 m × 3.000 m × 3.000 m  Pole: 54,  Objetosc: 27,  Dodanie: 9

            Console.WriteLine("Lista pudełek:\n");
            Display(pudelka);

            Console.WriteLine();
            Console.WriteLine("Posortowane pudełka:\n");

            pudelka.Sort(SortowaniePudelek);
            Display(pudelka);
        }
    }
}
