using PojazdyLib.Enums;
using PojazdyLib.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojazdyLib.Powietrzne
{
    public class Helicopter : AirVehicle 
    {
        private FuelType fuelType = FuelType.aviationKerosene; // Paliwo lotnicze 
        private int enginePower = 0;
        private bool isRotorsStarted = false;
        public new bool HasAnEngine => true;
        public new FuelType FuelType { get => fuelType; }
        public new int EnginePower { get => enginePower; }
        public bool IsRotorsStarted => isRotorsStarted; // Czy wirniki w helikopterze są rozpędzone
        public Helicopter(int enginePower)
        {
            if (enginePower > 5000 && enginePower < 20000) this.enginePower = enginePower;
            else
            {
                throw new ArgumentOutOfRangeException("Engine power is too low or too high!");
            }
        }
        public void StartRotors() // Włącza wirniki w helikopterze 
        {
            if (isRotorsStarted)
            {
                Console.WriteLine("Rotors already started.");
                return;
            }
            isRotorsStarted = true;
            Console.WriteLine("Rotors are on...");
        }
        public void StopRotors() // Wyłącza wirniki w helikopterze 
        {
            if (!isRotorsStarted)
            {
                Console.WriteLine("Rotors already stopped.");
                return;
            }
            isRotorsStarted = false;
            Console.WriteLine("Rotors are off...");
        }
        public new void IncreaseSpeed(double speed)
        {
            if (State == State.off)
            {
                Console.WriteLine("You can't increase speed, vehicle is off.");
                return;
            }
            if (!isRotorsStarted)
            {
                Console.WriteLine("The rotors are off.");
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
        public new void RiseUp()
        {
            if (State == State.on)
            {
                if (IsInTheAir)
                {
                    Console.WriteLine("Vehicle is already raised.");
                    return;
                }
                if (!isRotorsStarted)
                {
                    Console.WriteLine($"Turn the rotors on.");
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
        public new void Stop()
        {
            if (IsInTheAir)
            {
                Console.WriteLine("You can't stop the vehicle. You must land first.");
                return;
            }
            if (isRotorsStarted)
            {
                Console.WriteLine("Turn the rotors off.");
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
        public override string ToString() =>
           $"Pojazd: Helikopter \n" +
           $"Typ pojazdu: {VehicleType} \n" +
           $"Aktualne środowisko: {Environment} \n" +
           $"Aktualny stan: {State} \n" +
           $"Minimalna prędkość: {MinSpeed} {TextSpeedUnit(Unit)} \n" +
           $"Maksymalna prędkość: {MaxSpeed} {TextSpeedUnit(Unit)} \n" +
           $"Aktualna prędkość: {CurrentSpeed} {TextSpeedUnit(Unit)} \n" +
           $"Czy posiada silnik: {HasAnEngine} \n" +
           $"Moc silnika: {EnginePower} KM";
    }
}
