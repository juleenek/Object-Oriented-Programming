using PojazdyLib.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojazdyLib.Wodne
{
    public class Kayak : WaterVehicle
    {
        private int displacement;
        public new bool HasAnEngine => false;
        public new int Displacement { get => displacement; }
        public Kayak(int displacement)
        {
            if (displacement > 100 && displacement < 300) this.displacement = displacement;
            else
            {
                throw new ArgumentOutOfRangeException("Displacement is too low or too high!");
            }
        }
        public override string ToString() =>
           $"Pojazd: Kajak \n" +
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
