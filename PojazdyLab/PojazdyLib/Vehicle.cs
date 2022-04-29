using PojazdyLib.Enums;
using PojazdyLib.Interfejsy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojazdyLib
{
    public abstract class Vehicle : IVehicle
    {
        public State state;
        public double currentSpeed = 0;

        public State State = State.off;
        public double CurrentSpeed { get => currentSpeed; }
        public bool? CanVahicleBeStopped { get; private set; }
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
        static public string TextSpeedUnit(SpeedUnit speedUnit)
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
    }
}
