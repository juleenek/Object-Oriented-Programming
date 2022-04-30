using PojazdyLib.Ladowe;
using PojazdyLib.Powietrzne;
using System;
using PojazdyLib.PowietrzneLadowe;
using PojazdyLib.Wodne;
using PojazdyLib.WodneLadowe;
using System.Collections.Generic;
using PojazdyLib;
using PojazdyLib.VehicleTypes;
using System.Linq;

namespace PojazdyLab
{
    class Program
    {
        static void Main(string[] args)
        {
            // Samochód

            var samochod = new Car(PojazdyLib.Enums.FuelType.gasoline, 170);

            // --------- NA POTRZEBĘ LISTY ---------

            samochod.Start();
            samochod.IncreaseSpeed(50);

            // --------------- TEST ----------------

            //samochod.Start();
            //samochod.Stop();
            //samochod.IncreaseSpeed(350);
            //samochod.IncreaseSpeed(-350);
            //samochod.IncreaseSpeed(1350);
            //samochod.IncreaseSpeed(50);
            //samochod.Stop();
            //Console.WriteLine("\n" + samochod + "\n");

            //////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            // Lotnia

            var lotnia = new HangGlider();

            // --------- NA POTRZEBĘ LISTY ---------

            lotnia.Start();
            lotnia.IncreaseSpeed(26);
            lotnia.RiseUp();
            lotnia.IncreaseSpeed(10);

            // --------------- TEST ----------------

            //lotnia.Start();
            //lotnia.Stop();

            //lotnia.Land();
            //lotnia.RiseUp();

            //lotnia.Start();
            //lotnia.IncreaseSpeed(26);
            //lotnia.RiseUp();

            //lotnia.IncreaseSpeed(19);
            //lotnia.Stop();
            //Console.WriteLine("\n" + lotnia);

            //lotnia.Start();
            //lotnia.IncreaseSpeed(10);
            //Console.WriteLine("\n" + lotnia);
            //lotnia.RiseUp();

            //lotnia.Stop();
            //lotnia.IncreaseSpeed(200);

            //lotnia.ReduceSpeed(5);
            //lotnia.ReduceSpeed(21);
            //Console.WriteLine("\n" + lotnia);
            // lotnia.Stop();

            // lotnia.Land();
            // lotnia.ReduceSpeed(5);
            // Console.WriteLine("\n" + lotnia);
            // lotnia.Stop();


            //////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            // Helikopter

            var helikopter = new Helicopter(6000);

            // --------- NA POTRZEBĘ LISTY ---------

            helikopter.Start();
            helikopter.StartRotors();
            helikopter.IncreaseSpeed(25);
            helikopter.RiseUp();

            // --------------- TEST ----------------

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

            //Samolot

            var samolot = new Plane(10000, 12);

            // --------- NA POTRZEBĘ LISTY ---------

            samolot.Start();
            samolot.IncreaseSpeed(10);

            // --------------- TEST ----------------

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

            //samolot.ReduceSpeed(90);
            //Console.WriteLine("\n" + samolot + "\n");

            // samolot.Land();
            // Console.WriteLine("\n" + samolot + "\n");

            // samolot.Start();
            // samolot.Stop();
            // Console.WriteLine("\n" + samolot + "\n");



            //////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            // Szybowiec

            var szybowiec = new Glider();

            // --------- NA POTRZEBĘ LISTY ---------

            szybowiec.Start();
            szybowiec.IncreaseSpeed(23);
            szybowiec.RiseUp();
            szybowiec.IncreaseSpeed(5);

            // --------------- TEST ----------------

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

            var rower = new Bicycle();

            // --------- NA POTRZEBĘ LISTY ---------

            rower.Start();
            rower.IncreaseSpeed(2);

            // --------------- TEST ----------------

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

            var motocykl = new Motorcycle(160);

            // --------- NA POTRZEBĘ LISTY ---------

            motocykl.Start();

            // --------------- TEST ----------------

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

            var kajak = new Kayak(120);

            // --------- NA POTRZEBĘ LISTY ---------

            kajak.Start();
            kajak.GoToWater();
            kajak.IncreaseSpeed(20);

            // --------------- TEST ----------------

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

            var motorowka = new Motorboat(700, 250);

            // --------- NA POTRZEBĘ LISTY ---------

            motorowka.Start();
            motorowka.GoToWater();
            motorowka.IncreaseSpeed(40);

            // --------------- TEST ----------------

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


            //////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            // Łódź podwodna

            var podwodna = new Submarine(1500000, 50000);

            // --------- NA POTRZEBĘ LISTY ---------

            podwodna.Start();

            // --------------- TEST ----------------

            //podwodna.Start();
            //podwodna.IncreaseSpeed(20);

            //podwodna.GoToWater();
            //podwodna.IncreaseSpeed(20);
            //Console.WriteLine("\n" + podwodna + "\n");

            //podwodna.IncreaseSpeed(20);
            //Console.WriteLine("\n" + podwodna + "\n");

            //podwodna.IncreaseSpeed(1);
            //podwodna.IncreaseSpeed(-10);
            //podwodna.ReduceSpeed(5);
            //Console.WriteLine("\n" + podwodna + "\n");

            //podwodna.Start();
            //podwodna.Stop();
            //Console.WriteLine("\n" + podwodna + "\n");

            //podwodna.GoAshore();
            //podwodna.Start();
            //Console.WriteLine("\n" + podwodna + "\n");

            //podwodna.GoToWater();
            //podwodna.GoAshore();

            //Console.WriteLine("\n" + podwodna + "\n");



            //////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            // Amfibia 

            var amfibia = new Amphibious(2000, 700);

            // --------- NA POTRZEBĘ LISTY ---------

            amfibia.Start();
            amfibia.IncreaseSpeed(30);

            // --------------- TEST ----------------

            //amfibia.Start();
            //amfibia.IncreaseSpeed(30);

            //amfibia.GoToWater();
            //amfibia.IncreaseSpeed(5);
            //Console.WriteLine("\n" + amfibia + "\n");

            //amfibia.IncreaseSpeed(20);
            //Console.WriteLine("\n" + amfibia + "\n");

            //amfibia.IncreaseSpeed(1);
            //amfibia.IncreaseSpeed(-10);
            //amfibia.ReduceSpeed(5);
            //Console.WriteLine("\n" + amfibia + "\n");

            //amfibia.Start();
            //amfibia.Stop();
            //Console.WriteLine("\n" + amfibia + "\n");

            //amfibia.GoAshore();
            //amfibia.Start();
            //Console.WriteLine("\n" + amfibia + "\n");

            //amfibia.GoToWater();
            //amfibia.GoAshore();

            //amfibia.IncreaseSpeed(40);

            //Console.WriteLine("\n" + amfibia + "\n");

            /////////////////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            List<Vehicle> pojazdy = new List<Vehicle>() { samochod, rower, motocykl, lotnia, helikopter, szybowiec, kajak, motorowka, podwodna, amfibia };

            Console.WriteLine($"\nWszystkie pojazdy:");

            foreach (var pojazd in pojazdy)
            {
                Console.WriteLine("\n" + pojazd);
            }

            Console.WriteLine($"\nPojazdy lądowe:");

            foreach (var pojazd in pojazdy)
            {
                if (pojazd is LandVehicle && pojazd is not WaterVehicle && pojazd is not AirVehicle) Console.WriteLine("\n" + pojazd);
            }

            Console.WriteLine($"\nPojazdy rosnąco:");

            List<Vehicle> posortowanePojazdy = pojazdy.OrderBy(o =>
            {
                if (o.Unit == PojazdyLib.Enums.SpeedUnit.metersPerSecond)
                {
                    o.currentSpeed = Vehicle.ConvertUnits(PojazdyLib.Enums.SpeedUnit.metersPerSecond, PojazdyLib.Enums.SpeedUnit.kilometersPerHour, o.CurrentSpeed);
                    o.Unit = PojazdyLib.Enums.SpeedUnit.kilometersPerHour;
                } else if (o.Unit == PojazdyLib.Enums.SpeedUnit.nauticalMilePerHour)
                {
                    o.currentSpeed = Vehicle.ConvertUnits(PojazdyLib.Enums.SpeedUnit.nauticalMilePerHour, PojazdyLib.Enums.SpeedUnit.kilometersPerHour, o.CurrentSpeed);
                    o.Unit = PojazdyLib.Enums.SpeedUnit.kilometersPerHour;
                }
                return o.CurrentSpeed;
             
            }).ToList();

            foreach (var pojazd in posortowanePojazdy)
            {
                Console.WriteLine("\n" + pojazd);
            }
        }
    }
}
