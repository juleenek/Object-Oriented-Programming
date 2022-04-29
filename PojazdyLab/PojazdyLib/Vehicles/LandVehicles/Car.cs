using PojazdyLib.Enums;
using PojazdyLib.Interfejsy;
using PojazdyLib.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PojazdyLib.Ladowe
{
    public class Car : LandVehicle
    {
        private FuelType fuelType;
        private int enginePower;
        public new byte NumberOfWheels => 4;
        public new bool HasAnEngine => true;
        public new FuelType FuelType { get => fuelType; }
        public new int EnginePower { get => enginePower; }
        public Car(FuelType fuelType, int enginePower)
        {
            if (enginePower > 100 && enginePower < 990) this.enginePower = enginePower;
            else
            {
                throw new ArgumentOutOfRangeException("Engine power is too low or too high!");
            }
            this.fuelType = fuelType;
        }
        public override string ToString() => 
             $"Pojazd: Samochód \n" +
             $"Typ pojazdu: {VehicleType} \n" +
             $"Aktualne środowisko: {Environment} \n" +
             $"Aktualny stan: {State} \n" +
             $"Minimalna prędkość: {MinSpeed} {TextSpeedUnit(Unit)} \n" +
             $"Maksymalna prędkość: {MaxSpeed} {TextSpeedUnit(Unit)} \n" +
             $"Aktualna prędkość: {CurrentSpeed} {TextSpeedUnit(Unit)} \n" +
             $"Czy posiada silnik: {HasAnEngine} \n" +
             $"Liczba kół: {NumberOfWheels} \n" +
             $"Moc silnika: {EnginePower} KM";

    }
}
