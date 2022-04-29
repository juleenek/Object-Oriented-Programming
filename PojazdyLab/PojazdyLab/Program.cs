using PojazdyLib.Ladowe;
using PojazdyLib.Powietrzne;
using System;
using PojazdyLib.PowietrzneLadowe;
using PojazdyLib.Wodne;

namespace PojazdyLab
{
    class Program
    {
        static void Main(string[] args)
        {
            // Samochód

            //var car = new Car(PojazdyLib.Enums.FuelType.gasoline, 170);
            //car.Start();
            ////car.Stop();
            ////car.IncreaseSpeed(350);
            ////car.IncreaseSpeed(-350);
            ////car.IncreaseSpeed(1350);
            //car.IncreaseSpeed(50);
            //car.Stop();
            //Console.WriteLine("\n" + car + "\n");

            //////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            // Lotnia

            //var lotnia = new HangGlider();

            //Console.WriteLine("1\n");

            //lotnia.Start();
            //lotnia.Stop();

            // Console.WriteLine("\n2\n");

            // lotnia.Land();
            // lotnia.RiseUp();

            // Console.WriteLine("\n3\n");

            // lotnia.Start();
            // lotnia.IncreaseSpeed(26);
            // lotnia.RiseUp();

            // Console.WriteLine("\n4\n");

            // lotnia.IncreaseSpeed(19);
            // lotnia.Stop();
            // Console.WriteLine("\n" + lotnia);

            // Console.WriteLine("\n5\n");

            // lotnia.Start();
            // lotnia.IncreaseSpeed(10);
            // Console.WriteLine("\n" + lotnia);
            // lotnia.RiseUp();

            // Console.WriteLine("\n6\n");

            // lotnia.Stop();
            // lotnia.IncreaseSpeed(200);
            // Console.WriteLine("\n" + lotnia);

            // Console.WriteLine("\n7\n");

            // lotnia.ReduceSpeed(5);
            // Console.WriteLine("\n" + lotnia);
            // lotnia.ReduceSpeed(21);
            // lotnia.Stop();
            // Console.WriteLine("\n" + lotnia);
            // lotnia.Land();
            // lotnia.ReduceSpeed(5);
            // Console.WriteLine("\n" + lotnia);
            // lotnia.Stop();


            //////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            // Helikopter

            //var helikopter = new Helicopter(6000);

            //helikopter.Start();

            //helikopter.IncreaseSpeed(10);
            //helikopter.RiseUp();

            //helikopter.StartRotors();
            //helikopter.IncreaseSpeed(10);
            //helikopter.RiseUp();

            //helikopter.IncreaseSpeed(15);
            //helikopter.RiseUp();

            //Console.WriteLine("\n" + helikopter + "\n");

            //helikopter.IncreaseSpeed(230);
            //helikopter.ReduceSpeed(30);
            //helikopter.ReduceSpeed(3);

            //Console.WriteLine("\n" + helikopter + "\n");

            //helikopter.Stop();
            //helikopter.Land();
            //helikopter.Stop();

            //helikopter.StopRotors();
            //helikopter.Stop();

            //Console.WriteLine("\n" + helikopter + "\n");


            //////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            // Samolot

            //var samolot = new Plane(10000, 12);
            //samolot.Start();
            //samolot.IncreaseSpeed(18);

            //Console.WriteLine("\n" + samolot + "\n");

            //samolot.IncreaseSpeed(20);
            //Console.WriteLine("\n" + samolot + "\n");

            //samolot.IncreaseSpeed(5);
            //Console.WriteLine("\n" + samolot + "\n");

            //samolot.RiseUp();
            //Console.WriteLine("\n" + samolot + "\n");

            //samolot.IncreaseSpeed(100);
            //samolot.ReduceSpeed(10);
            //samolot.Land();
            //samolot.Stop();
            //Console.WriteLine("\n" + samolot + "\n");

            //samolot.ReduceSpeed(110);
            //Console.WriteLine("\n" + samolot + "\n");

            //samolot.Land();
            //Console.WriteLine("\n" + samolot + "\n");

            //samolot.Start();
            //samolot.Stop();
            //Console.WriteLine("\n" + samolot + "\n");



            //////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            // Szybowiec

            //var szybowiec = new Glider();

            //szybowiec.Stop();
            //szybowiec.Start();

            //szybowiec.IncreaseSpeed(15);
            //Console.WriteLine("\n" + szybowiec + "\n");

            //szybowiec.IncreaseSpeed(10);
            //szybowiec.RiseUp();
            //Console.WriteLine("\n" + szybowiec + "\n");

            //szybowiec.ReduceSpeed(20);
            //szybowiec.IncreaseSpeed(20);
            //szybowiec.ReduceSpeed(10);
            //Console.WriteLine("\n" + szybowiec + "\n");

            //szybowiec.Stop();
            //szybowiec.Land();

            //szybowiec.ReduceSpeed(10);
            //szybowiec.Land();
            //Console.WriteLine("\n" + szybowiec + "\n");

            //szybowiec.Stop();
            //Console.WriteLine("\n" + szybowiec + "\n");


            //////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            // Rower 

            //var rower = new Bicycle();

            //rower.Start();
            //rower.Stop();
            //rower.Start();

            //rower.IncreaseSpeed(100);
            //rower.IncreaseSpeed(-350);
            //rower.IncreaseSpeed(1350);
            //Console.WriteLine("\n" + rower + "\n");

            //rower.IncreaseSpeed(50);
            //rower.IncreaseSpeed(100);
            //Console.WriteLine("\n" + rower + "\n");

            //rower.Start();
            //rower.Stop();


            //////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            // Motocykl

            ////var motocykl = new Motorcycle(50);
            //var motocykl = new Motorcycle(160);

            //motocykl.Start();
            //motocykl.Stop();
            //motocykl.Start();

            //motocykl.IncreaseSpeed(1);
            //motocykl.IncreaseSpeed(-350);
            //motocykl.IncreaseSpeed(1350);
            //Console.WriteLine("\n" + motocykl + "\n");

            //motocykl.IncreaseSpeed(50);
            //motocykl.IncreaseSpeed(100);
            //Console.WriteLine("\n" + motocykl + "\n");

            //motocykl.Start();
            //motocykl.Stop();


            //////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            // Kajak

            //var kajak = new Kayak(120);

            //kajak.Start();
            //kajak.IncreaseSpeed(20);

            //kajak.GoToWater();
            //kajak.IncreaseSpeed(20);
            //Console.WriteLine("\n" + kajak + "\n");

            //kajak.IncreaseSpeed(20);
            //Console.WriteLine("\n" + kajak + "\n");

            //kajak.IncreaseSpeed(1);
            //kajak.IncreaseSpeed(-10);
            //kajak.ReduceSpeed(5);
            //Console.WriteLine("\n" + kajak + "\n");

            //kajak.Start();
            //kajak.Stop();
            //Console.WriteLine("\n" + kajak + "\n");



            //////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            // Motorówka 

            ////var motorowka = new Motorboat(10);
            //var motorowka = new Motorboat(700);

            //motorowka.Start();
            //motorowka.IncreaseSpeed(20);

            //motorowka.GoToWater();
            //motorowka.IncreaseSpeed(20);
            //Console.WriteLine("\n" + motorowka + "\n");

            //motorowka.IncreaseSpeed(20);
            //Console.WriteLine("\n" + motorowka + "\n");

            //motorowka.IncreaseSpeed(1);
            //motorowka.IncreaseSpeed(-10);
            //motorowka.ReduceSpeed(5);
            //Console.WriteLine("\n" + motorowka + "\n");

            //motorowka.Start();
            //motorowka.Stop();
            //Console.WriteLine("\n" + motorowka + "\n");

            //motorowka.GoAshore();
            //motorowka.Start();
            //Console.WriteLine("\n" + motorowka + "\n");

            //motorowka.GoToWater();
            //motorowka.GoAshore();

            //Console.WriteLine("\n" + motorowka + "\n");

        }
    }
}
