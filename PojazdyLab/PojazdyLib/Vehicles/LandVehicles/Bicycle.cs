using PojazdyLib.Enums;
using PojazdyLib.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojazdyLib.Ladowe
{
    public class Bicycle : LandVehicle
    {
        private FuelType fuelType = FuelType.none;
        private int enginePower = 0;
        public new byte NumberOfWheels => 2;
        public new bool HasAnEngine => false;
        public new FuelType FuelType { get => fuelType; }
        public new int EnginePower { get => enginePower; }
        public override string ToString() =>
             $"Pojazd: Rower \n" +
             $"Typ pojazdu: {VehicleType} \n" +
             $"Aktualne środowisko: {Environment} \n" +
             $"Aktualny stan: {State} \n" +
             $"Minimalna prędkość: {MinSpeed} {TextSpeedUnit(Unit)} \n" +
             $"Maksymalna prędkość: {MaxSpeed} {TextSpeedUnit(Unit)} \n" +
             $"Aktualna prędkość: {CurrentSpeed} {TextSpeedUnit(Unit)} \n" +
             $"Czy posiada silnik: {HasAnEngine} \n" +
             $"Liczba kół: {NumberOfWheels}";
    }
}
