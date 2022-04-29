using System;
using PojazdyLib.Interfejsy;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PojazdyLib.Enums;
using System.Threading;

namespace PojazdyLib.VehicleTypes
{
    public class AirVehicle : Vehicle, IAirVehicle
    {
        public double LandingRisingBoundary => 10.0; // Granica od której pojazd się wznosi i ląduje
        public bool HasAnEngine => false;
        public FuelType FuelType => FuelType.none;
        public int EnginePower => 0;

        public bool isInTheAir = false;
        public string environment = "Lądowe";
        public string Environment => environment;
        public string VehicleType => "Powietrzny";
        public double MinSpeed => 20;

        public double MaxSpeed => 200;

        public SpeedUnit Unit => SpeedUnit.metersPerSecond;
        public bool IsInTheAir => isInTheAir;

        public void RiseUp()
        {
            if (State == State.on)
            {
                if (IsInTheAir)
                {
                    Console.WriteLine("Vehicle is already raised.");
                    return;
                }
                if (CurrentSpeed <= MinSpeed)
                {
                    Console.WriteLine("Too low speed to rise up.");
                    return;
                }
                if (currentSpeed >= MinSpeed + LandingRisingBoundary)
                {
                    Console.WriteLine($"Too high speed to rise up, please try lower (20-{(int)LandingRisingBoundary} m/s).");
                    return;
                }
                isInTheAir = true;
                environment = "Powietrzne";
                Console.WriteLine("Vehicle rises ...");
                return;
            }
            Console.WriteLine("Vehicle is off.");
        }
        public void Land()
        {
            if (State == State.on)
            {
                if (!IsInTheAir)
                {
                    Console.WriteLine("Vehicle has already landed.");
                    return;
                }
                if (currentSpeed >= MinSpeed + LandingRisingBoundary)
                {
                    Console.WriteLine("Too high speed to land.");
                    return;
                }
                if (currentSpeed <= MinSpeed)
                {
                    Console.WriteLine($"Speed is too low, try landing gradually (20-{(int)LandingRisingBoundary} m/s).");
                    return;
                }

                isInTheAir = false;
                environment = "Lądowe";
                Console.WriteLine("Vehicle landing ...");
                return;
            }
            Console.WriteLine("Vehicle is off.");
        }
        public new void IncreaseSpeed(double speed)
        {
            if (State == State.off)
            {
                Console.WriteLine("You can't increase speed, vehicle is off.");
                return;
            }
            if (!IsInTheAir && currentSpeed + speed > MinSpeed + LandingRisingBoundary)
            {
                Console.WriteLine("Try lower speed.");
                return;
            }
            if ((IsInTheAir && currentSpeed + speed <= MaxSpeed && currentSpeed + speed > MinSpeed) ||
                (!IsInTheAir && currentSpeed + speed < MinSpeed + LandingRisingBoundary && currentSpeed + speed > 0))
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
            if (!IsInTheAir && currentSpeed - speed < 0)
            {
                Console.WriteLine("Try higher speed.");
                return;
            }
            if ((IsInTheAir && currentSpeed - speed <= MaxSpeed && currentSpeed - speed > MinSpeed) ||
                (!IsInTheAir && currentSpeed - speed < MinSpeed + LandingRisingBoundary && currentSpeed - speed > 0))
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

        public new void Stop()
        {
            if (IsInTheAir)
            {
                Console.WriteLine("You can't stop the vehicle. You must land first.");
                return;
            }
          
            if (State == State.on)
            {
                State = State.off;
                currentSpeed = 0;
                Console.WriteLine("Vehicle is off ...");
                return;
            }
            Console.WriteLine("Vehicle is already off.");
        }  
    }
}
