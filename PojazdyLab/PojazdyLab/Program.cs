using PojazdyLib.Ladowe;
using PojazdyLib.Powietrzne;
using System;

namespace PojazdyLab
{
    class Program
    {
        static void Main(string[] args)
        {
            // Samochód

            //var car = new Car(PojazdyLib.Enums.FuelType.gasoline, 50);
            //car.Start();
            ////car.Stop();
            ////car.IncreaseSpeed(350);
            ////car.IncreaseSpeed(-350);
            ////car.IncreaseSpeed(1350);
            //car.IncreaseSpeed(50);
            //Console.WriteLine("\n" + car + "\n");

            // Lotnia

            //var lotnia = new HangGlider();

            //Console.WriteLine("1\n");

            //lotnia.Start();
            //lotnia.Stop();

            //Console.WriteLine("\n2\n");

            //lotnia.Land();
            //lotnia.RiseUp();

            //Console.WriteLine("\n3\n");

            //lotnia.Start();
            //lotnia.IncreaseSpeed(26);
            //lotnia.RiseUp();

            //Console.WriteLine("\n4\n");

            //lotnia.IncreaseSpeed(19);
            //lotnia.Stop();
            //Console.WriteLine("\n" + lotnia);

            //Console.WriteLine("\n5\n");

            //lotnia.Start();
            //lotnia.IncreaseSpeed(10);
            //Console.WriteLine("\n" + lotnia);
            //lotnia.RiseUp();

            //Console.WriteLine("\n6\n");

            //lotnia.Stop();
            //lotnia.IncreaseSpeed(200);
            //Console.WriteLine("\n" + lotnia);

            //Console.WriteLine("\n7\n");

            //lotnia.ReduceSpeed(5);
            //Console.WriteLine("\n" + lotnia);
            //lotnia.ReduceSpeed(21);
            //lotnia.Stop();
            //Console.WriteLine("\n" + lotnia);
            //lotnia.Land();
            //lotnia.ReduceSpeed(5);
            //Console.WriteLine("\n" + lotnia);
            //lotnia.Stop();

            // Helikopter

            var helikopter = new Helicopter(6000);

            helikopter.Start();

            helikopter.IncreaseSpeed(10);
            helikopter.RiseUp();


            helikopter.IncreaseSpeed(15);
            helikopter.RiseUp();

            Console.WriteLine("\n" + helikopter + "\n");

            helikopter.IncreaseSpeed(230);
            helikopter.ReduceSpeed(30);
            helikopter.ReduceSpeed(3);

            Console.WriteLine("\n" + helikopter + "\n");

            helikopter.Stop();
            helikopter.Land();
            helikopter.Stop();

            Console.WriteLine("\n" + helikopter + "\n");
        }
    }
}
