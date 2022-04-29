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
    public class WaterVehicle : Vehicle, IWaterVehicle
    {
        private bool isOnWater = false;
        public bool HasAnEngine => false;
        public FuelType FuelType => FuelType.none;
        public int EnginePower => 0;
        private string environment;
        public string Environment { get => environment; }
        public string VehicleType => "Wodny";
        public double MinSpeed => 1;
        public double MaxSpeed => 40;
        public SpeedUnit Unit => SpeedUnit.nauticalMilePerHour;
        public int Displacement => 0;
        public bool IsOnWater { get => isOnWater; }
        public void GoToWater()
        {
            if (State == State.on)
            {
                if (IsOnWater)
                {
                    Console.WriteLine("Vehicle is already on the water.");
                    return;
                }
                isOnWater = true;
                environment = "Wodne";
                Console.WriteLine("Vehicle is in the water ...");
                return;
            }
            Console.WriteLine("Vehicle is off or too low speed.");
        }
        public void GoAshore()
        {
            if (State == State.on)
            {
                if (!IsOnWater)
                {
                    Console.WriteLine("Vehicle is already on land.");
                    return;
                }
                isOnWater = false;
                environment = "Lądowe";
                Console.WriteLine("Vehicle is on land ...");
                return;
            }
            Console.WriteLine("Vehicle is off or too low speed.");
        }
        public new void IncreaseSpeed(double speed)
        {
            if (State == State.off)
            {
                Console.WriteLine("You can't increase speed, vehicle is off.");
                return;
            }
            if (!IsOnWater)
            {
                Console.WriteLine("Vehicle is not on the water.");
                return;
            }
            if (IsOnWater && currentSpeed + speed <= MaxSpeed && currentSpeed + speed > MinSpeed && speed > 0)
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
            if (!IsOnWater)
            {
                Console.WriteLine("Vehicle is not on the water.");
                return;
            }
            if (IsOnWater && currentSpeed - speed <= MaxSpeed && currentSpeed - speed > MinSpeed && speed > 0)
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
    }
}
