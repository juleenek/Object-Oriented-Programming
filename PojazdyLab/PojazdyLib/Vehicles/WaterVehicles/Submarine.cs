using PojazdyLib.Enums;
using PojazdyLib.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojazdyLib.Wodne
{
    public class Submarine : WaterVehicle
    {
        private int displacement;
        private int enginePower;
        public new bool HasAnEngine => true;
        public new int Displacement { get => displacement; }
        public new int EnginePower { get => enginePower; }
        public Submarine(int displacement, int enginePower)
        {
            if (displacement > 1000000 && displacement < 48000000) this.displacement = displacement;
            else
            {
                throw new ArgumentOutOfRangeException("Displacement is too low or too high!");
            }
            if (enginePower > 40000 && enginePower < 250000) this.enginePower = enginePower;
            else
            {
                throw new ArgumentOutOfRangeException("Engine power is too low or too high!");
            }
        }
        public override string ToString() =>
           $"Pojazd: Łódź podwodna \n" +
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

// We are live in the yellow submarine