using PojazdyLib.Enums;
using PojazdyLib.Interfejsy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PojazdyLib.VehicleTypes
{
    public class LandVehicle : Vehicle, ILandVehicle
    {
        public string VehicleType => "Pojazd lądowy";
        public string Environment => "Lądowe";
        public double MinSpeed => 1.0;
        public double MaxSpeed => 350.0;
        public byte NumberOfWheels => 0;
        public bool HasAnEngine => false;
        public FuelType FuelType => FuelType.none;
        public int EnginePower => 0;
        public SpeedUnit Unit => SpeedUnit.kilometersPerHour;

        public new void IncreaseSpeed(double speed)
        {
            if (State == State.on && speed >= MinSpeed && speed <= MaxSpeed && currentSpeed + speed <= MaxSpeed && speed > 0)
            {
                int partialNum = 4;
                double partialSpeed = (speed / (double)partialNum);

                for (int i = 0; i < partialNum; i++)
                {
                    currentSpeed += partialSpeed;
                    Console.WriteLine($"Speed increased by {partialSpeed} {TextSpeedUnit(Unit)} ...");
                    Thread.Sleep(2000);
                }
            }
            else
            {
                Console.WriteLine("You can't increase speed.");
            }
        }
        public new void ReduceSpeed(double speed)
        {
            if (State == State.on && speed >= MinSpeed && speed < MaxSpeed && currentSpeed - speed >= MinSpeed && speed > 0)
            {
                int partialNum = 4;
                double partialSpeed = (speed / (double)partialNum);

                for (int i = 0; i < partialNum; i++)
                {
                    currentSpeed -= partialSpeed;
                    Console.WriteLine($"Speed reduced by {partialSpeed} {TextSpeedUnit(Unit)} ...");
                    Thread.Sleep(2000);
                }
            }
            else
            {
                Console.WriteLine("You can't reduce speed.");
            }
        }

    }
}
