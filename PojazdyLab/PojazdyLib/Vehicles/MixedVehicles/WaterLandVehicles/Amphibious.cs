using PojazdyLib.Enums;
using PojazdyLib.Interfejsy;
using PojazdyLib.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PojazdyLib.WodneLadowe
{
    public class Amphibious : WaterVehicle, ILandVehicle
    {
        private int displacement;
        private int enginePower;
        public new bool HasAnEngine => true;
        public new int Displacement { get => displacement; }
        public new int EnginePower { get => enginePower; }
        public byte NumberOfWheels => 6;

        public Amphibious(int displacement, int enginePower)
        {
            if (displacement > 1000 && displacement < 4000) this.displacement = displacement;
            else
            {
                throw new ArgumentOutOfRangeException("Displacement is too low or too high!");
            }
            if (enginePower > 600 && enginePower < 800) this.enginePower = enginePower;
            else
            {
                throw new ArgumentOutOfRangeException("Engine power is too low or too high!");
            }
        }
        public new void IncreaseSpeed(double speed)
        {
            if (State == State.off)
            {
                Console.WriteLine("You can't increase speed, vehicle is off.");
                return;
            }
            if (currentSpeed + speed <= MaxSpeed && currentSpeed + speed >= 0 && speed > 0)
            {
                int partialNum = 4;
                double partialSpeed = (speed / (double)partialNum);

                for (int i = 0; i < partialNum; i++)
                {
                    currentSpeed += partialSpeed;
                    Console.WriteLine($"Speed increased by {partialSpeed} {TextSpeedUnit(Unit)} ...");
                    //Thread.Sleep(2000);
                }
                return;
            }
            Console.WriteLine("You can't increase speed.");
        }
        public new void ReduceSpeed(double speed)
        {
            if (State == State.off)
            {
                Console.WriteLine("You can't reduce speed, vehicle is off.");
                return;
            }
            if (currentSpeed - speed <= MaxSpeed && currentSpeed - speed > 0 && speed > 0)
            {
                int partialNum = 4;
                double partialSpeed = (speed / (double)partialNum);

                for (int i = 0; i < partialNum; i++)
                {
                    currentSpeed -= partialSpeed;
                    Console.WriteLine($"Speed reduced by {partialSpeed} {TextSpeedUnit(Unit)} ...");
                    //Thread.Sleep(2000);
                }
                return;
            }
            Console.WriteLine("You can't reduce speed.");
        }
        public override string ToString() =>
           $"Pojazd: Amfibia \n" +
           $"Typ pojazdu: {VehicleType} \n" +
           $"Aktualne środowisko: {Environment} \n" +
           $"Aktualny stan: {State} \n" +
           $"Minimalna prędkość: {MinSpeed} {TextSpeedUnit(Unit)} \n" +
           $"Maksymalna prędkość: {MaxSpeed} {TextSpeedUnit(Unit)} \n" +
           $"Aktualna prędkość: {CurrentSpeed} {TextSpeedUnit(Unit)} \n" +
           $"Czy posiada silnik: {HasAnEngine} \n" +
           $"Moc silnika: {EnginePower} KM \n" +
           $"Wyporność: {Displacement} kg";
    }
}
