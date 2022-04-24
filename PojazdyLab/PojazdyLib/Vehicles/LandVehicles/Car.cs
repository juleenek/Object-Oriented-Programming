using PojazdyLib.Enums;
using PojazdyLib.Interfejsy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojazdyLib.Ladowe
{
    public class Car : Vehicle, ILandVehicle
    {
        private FuelType fuelType;
        private int enginePower;
        public byte NumberOfWheels => 4;

        public int MinSpeed => 1;

        public int MaxSpeed => 350;

        public SpeedUnit Unit => SpeedUnit.kilometersPerHour;

        public bool HasAnEngine => true;

        public FuelType FuelType { get => fuelType; }

        public int EnginePower { get => enginePower; }
        public Car(FuelType fuelType, int enginePower)
        {
            this.fuelType = fuelType;
            this.enginePower = enginePower;
        }
        public new void IncreaseSpeed(int speed)
        {
            if (State == State.on && speed >= MinSpeed && speed < MaxSpeed && currentSpeed + speed <= MaxSpeed )
            {
                currentSpeed += speed;
                Console.WriteLine("Speed increased ...");
            }
            else
            {
                Console.WriteLine("You can't increase speed.");
            }
        }
        public new void ReduceSpeed(int speed)
        {
            if (State == State.on && speed >= MinSpeed && speed < MaxSpeed && currentSpeed - speed >= MinSpeed)
            {
                currentSpeed -= speed;
                Console.WriteLine("Speed reduced ...");
            }
            else
            {
                Console.WriteLine("You can't reduce speed.");
            }
        }
    }
}
