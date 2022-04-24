using PojazdyLib.Ladowe;
using System;

namespace PojazdyLab
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car(PojazdyLib.Enums.FuelType.gasoline, 50);
            car.Start();
            car.IncreaseSpeed(60);
            Console.WriteLine(car.CurrentSpeed);
        }
    }
}
