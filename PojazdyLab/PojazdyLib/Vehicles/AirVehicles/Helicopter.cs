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
        public new bool HasAnEngine => true;
        public new FuelType FuelType { get => fuelType; }
        public new int EnginePower { get => enginePower; }
        public Helicopter(int enginePower)
        {
            if (enginePower > 5000 && enginePower < 20000) this.enginePower = enginePower;
            else
            {
                throw new ArgumentOutOfRangeException("Engine power is too low or too high!");
            }
        }
        public override string ToString() =>
           $"Pojazd: Helikopter \n" +
           $"Typ pojazdu: {VehicleType} \n" +
           $"Aktualne środowisko: {Environment} \n" +
           $"Aktualny stan: {State} \n" +
           $"Minimalna prędkość: {MinSpeed} {TextSpeedUnit(Unit)} \n" +
           $"Maksymalna prędkość: {MaxSpeed} {TextSpeedUnit(Unit)} \n" +
           $"Aktualna prędkość: {CurrentSpeed} {TextSpeedUnit(Unit)} \n" +
           $"Czy posiada silnik: {HasAnEngine} \n";
    }
}
