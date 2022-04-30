using PojazdyLib.Enums;
using PojazdyLib.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojazdyLib.Wodne
{
    public class Motorboat : WaterVehicle
    {
        private int displacement;
        private int enginePower;
        public new bool HasAnEngine => true;
        public new FuelType FuelType { get => FuelType.gasoline; }
        public new int Displacement { get => displacement; }
        public new int EnginePower { get => enginePower; }
        public Motorboat(int displacement, int enginePower)
        {
            if (displacement > 600 && displacement < 1000) this.displacement = displacement;
            else
            {
                throw new ArgumentOutOfRangeException("Displacement is too low or too high!");
            }
            if (enginePower > 200 && enginePower < 400) this.enginePower = enginePower;
            else
            {
                throw new ArgumentOutOfRangeException("Engine power is too low or too high!");
            }
        }
        public override string ToString() =>
           $"Pojazd: Motorówka \n" +
           $"Typ pojazdu: {VehicleType} \n" +
           $"Aktualne środowisko: {Environment} \n" +
           $"Aktualny stan: {State} \n" +
           $"Minimalna prędkość: {MinSpeed} {TextSpeedUnit(Unit)} \n" +
           $"Maksymalna prędkość: {MaxSpeed} {TextSpeedUnit(Unit)} \n" +
           $"Aktualna prędkość: {CurrentSpeed} {TextSpeedUnit(Unit)} \n" +
           $"Czy posiada silnik: {HasAnEngine} \n" +
           $"Moc silnika: {EnginePower} KM \n" +
           $"Wyporność: {Displacement} kg";
    }
}
