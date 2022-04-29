using PojazdyLib.Enums;
using PojazdyLib.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojazdyLib.Ladowe
{
    public class Motorcycle : LandVehicle
    {
        private FuelType fuelType = FuelType.gasoline;
        private int enginePower;
        public new byte NumberOfWheels => 2;
        public new bool HasAnEngine => true;
        public new FuelType FuelType { get => fuelType; }
        public new int EnginePower { get => enginePower; }
        public Motorcycle(int enginePower)
        {
            if (enginePower > 150 && enginePower < 200) this.enginePower = enginePower;
            else
            {
                throw new ArgumentOutOfRangeException("Engine power is too low or too high!");
            }
        }
        public override string ToString() =>
             $"Pojazd: Rower \n" +
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
