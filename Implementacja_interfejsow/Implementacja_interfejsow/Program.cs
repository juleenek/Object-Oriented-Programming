using System;

namespace Implementacja_interfejsow
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Pracownik();
            p1.Wynagrodzenie = 100;
            p1.Nazwisko = "   Molenda  ";
            p1.DataZatrudnienia = new DateTime(2010, 10, 01);



            var p2 = new Pracownik();
            p2.Wynagrodzenie = 100;
            p2.Nazwisko = "   Molenda  ";
            p2.DataZatrudnienia = new DateTime(2010, 10, 01);


            Console.WriteLine(Pracownik.ReferenceEquals(p1, p2));
            Console.WriteLine(Pracownik.Equals(p1, p2));
        }
    }
}

