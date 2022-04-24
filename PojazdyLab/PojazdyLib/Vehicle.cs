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
        public int currentSpeed = 0;

        public State State = State.off;
        public int CurrentSpeed { get => currentSpeed; }
        public bool? CanVahicleBeStopped { get; private set; }
        public void IncreaseSpeed(int speed)
        {
            currentSpeed += speed;
            Console.WriteLine("Speed increased ...");
        }

        public void ReduceSpeed(int speed)
        {
            currentSpeed -= speed;
            Console.WriteLine("Speed reduced ...");
        }

        public void Start()
        {
            State = State.on;
            Console.WriteLine("Vehicle is on ...");
        }

        public void Stop()
        {
            State = State.off;
            Console.WriteLine("Vehicle is off ...");
        }
    }
}
