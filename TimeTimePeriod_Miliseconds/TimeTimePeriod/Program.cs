using System;
using System.Threading;
using TimeTimePeriod_Lib;

namespace TimeTimePeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj!\nJeśli chcesz użyć zegara, wciśnij \"Z\", jeśli chcesz użyć stopera wciśnij \"S\"");

            ConsoleKeyInfo key = Console.ReadKey();

            while (key.KeyChar.ToString() != "Z" && key.KeyChar.ToString() != "S" && key.KeyChar.ToString() != "s" && key.KeyChar.ToString() != "z") {
                Console.WriteLine("\nZły znak\nJeśli chcesz użyć zegara, wciśnij \"Z\", jeśli chcesz użyć stopera wciśnij \"S\"");
                key = Console.ReadKey();
            }

            // ZEGAR 

            if (key.KeyChar.ToString() == "Z" || key.KeyChar.ToString() == "z")
            {
                Console.WriteLine("\nWybrany został zegar, wprowadź godzinę w formacie \"HH:MM:SS:mmm\"");

                while (true)
                {
                    var input = Console.ReadLine();

                    try
                    {
                        Time time = new Time(input);
                        while (true)
                        {
                            time += new TimePeriod(0, 0, 1, 0);
                            Thread.Sleep(1000);
                            Console.WriteLine(time);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wprowadź pooprawny format");
                    }
                }
            }

            // STOPER

            if (key.KeyChar.ToString() == "S" || key.KeyChar.ToString() == "s")
            {
                Console.WriteLine("\nWybrany został stoper, wprowadź godzinę w formacie \"HH:MM:SS:mmm\"\n" +
                    "Po uruchomieniu stopera, w celu jego zatrzymania wciśnij dowolny klawisz");

                while (true)
                {
                    var input = Console.ReadLine();

                    try
                    {
                        Time time = new Time(input);

                        while (true)
                        {                      
                            time += new TimePeriod(0, 0, 0, 1);
                            Thread.Sleep(1);
                            Console.WriteLine(time);
                            if (Console.KeyAvailable == true)
                            {
                                Console.WriteLine("Stoper zatrzymany");
                                return;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wprowadź pooprawny format");
                    }
                }
            }
        }
    }
}
