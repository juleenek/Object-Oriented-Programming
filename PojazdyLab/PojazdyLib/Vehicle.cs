using PojazdyLib.Enums;
using PojazdyLib.Interfejsy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojazdyLib
{
    public abstract class Vehicle : IVehicle, IComparable<Vehicle>
    {
        public State state;
        private SpeedUnit unit;
        public double currentSpeed = 0;
        public State State = State.off;
        public string Environment;
        public SpeedUnit Unit => unit;
        public double CurrentSpeed { get => currentSpeed; }
        public bool? CanVahicleBeStopped { get; private set; }
        internal Vehicle()
        {
            if(this is IAirVehicle)
            {
                unit = SpeedUnit.metersPerSecond;
                return;
            }
            else if(this is IWaterVehicle)
            {
                unit = SpeedUnit.nauticalMilePerHour;
                return;
            }
            unit = SpeedUnit.kilometersPerHour;
        }
        public void IncreaseSpeed(double speed)
        {
            currentSpeed += speed;
            Console.WriteLine("Speed increased ...");
        }

        public void ReduceSpeed(double speed)
        {
            currentSpeed -= speed;
            Console.WriteLine("Speed reduced ...");
        }

        public void Start()
        {
            if (State == State.off)
            {
                State = State.on;
                currentSpeed = 0;
                Console.WriteLine("Vehicle is on ...");
            } else
            {
                Console.WriteLine("Vehicle is already on.");
            }
        }

        public void Stop()
        {
            if (State == State.on)
            {
                State = State.off;
                currentSpeed = 0;
                Console.WriteLine("Vehicle is off ...");
            }
            else
            {
                Console.WriteLine("Vehicle is already off.");
            }
        }
        public static string TextSpeedUnit(SpeedUnit speedUnit)
        {
            switch (speedUnit)
            {
                case SpeedUnit.kilometersPerHour:
                    return "k/h";
                case SpeedUnit.nauticalMilePerHour:
                    return "knot";
                case SpeedUnit.metersPerSecond:
                    return "m/s";
                default:
                    return "";
            }
        }
        public static double ConvertUnits(SpeedUnit currentUnit, SpeedUnit toUnit, double value)
        {
            double result = 0.0;

            switch (toUnit)
            {
                case SpeedUnit.kilometersPerHour:
                    if (currentUnit == SpeedUnit.metersPerSecond) result = value * 3.6;
                    if (currentUnit == SpeedUnit.nauticalMilePerHour) result = value * 1.85;
                    if (currentUnit == SpeedUnit.kilometersPerHour) result = value;
                    return result;
                case SpeedUnit.nauticalMilePerHour:
                    if (currentUnit == SpeedUnit.kilometersPerHour) result = value * 0.54;
                    if (currentUnit == SpeedUnit.nauticalMilePerHour) result = value;
                    if (currentUnit == SpeedUnit.metersPerSecond) result = value * 1.94;
                    return result;
                case SpeedUnit.metersPerSecond:
                    if (currentUnit == SpeedUnit.kilometersPerHour) result = value * 0.28;
                    if (currentUnit == SpeedUnit.nauticalMilePerHour) result = value * 0.51;
                    if (currentUnit == SpeedUnit.metersPerSecond) result = value;
                    return result;
                default:
                    return result;
            }
        }
        public int CompareTo(Vehicle other)
        {
            var convertedSpeed = ConvertUnits(Unit, SpeedUnit.kilometersPerHour, CurrentSpeed);
            var convertedOtherSpeed = ConvertUnits(other.Unit, SpeedUnit.kilometersPerHour, other.CurrentSpeed);

            if (convertedSpeed > convertedOtherSpeed)
                return 1;
            if (convertedSpeed < convertedOtherSpeed)
                return -1;

            return 0;
        }
    }
}
