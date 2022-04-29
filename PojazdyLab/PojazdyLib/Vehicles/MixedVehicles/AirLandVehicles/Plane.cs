using PojazdyLib.Enums;
using PojazdyLib.Interfejsy;
using PojazdyLib.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojazdyLib.PowietrzneLadowe
{
    public class Plane : AirVehicle, ILandVehicle
    {
        private FuelType fuelType = FuelType.aviationKerosene;
        private int enginePower = 0;
        private byte numberOfWheels = 0;
        public new bool HasAnEngine => true;
        public new FuelType FuelType { get => fuelType; }
        public new int EnginePower { get => enginePower; }
        public byte NumberOfWheels { get => numberOfWheels; } 

        public Plane(int enginePower, byte numberOfWheels)
        {
            if (enginePower > 5000 && enginePower < 60000) this.enginePower = enginePower;
            else
            {
                throw new ArgumentOutOfRangeException("Engine power is too low or too high!");
            }
            if (numberOfWheels >= 10 && numberOfWheels <= 18 && numberOfWheels % 2 == 0) this.numberOfWheels = numberOfWheels;
            else
            {
                throw new ArgumentOutOfRangeException("The number of wheels is too small or too large or odd!");
            }
        }
        public override string ToString() =>
            $"Pojazd: Samolot \n" +
            $"Typ pojazdu: {VehicleType} \n" +
            $"Aktualne środowisko: {Environment} \n" +
            $"Aktualny stan: {State} \n" +
            $"Minimalna prędkość: {MinSpeed} {TextSpeedUnit(Unit)} \n" +
            $"Maksymalna prędkość: {MaxSpeed} {TextSpeedUnit(Unit)} \n" +
            $"Aktualna prędkość: {CurrentSpeed} {TextSpeedUnit(Unit)} \n" +
            $"Czy posiada silnik: {HasAnEngine} \n" +
            $"Ilość kół: {NumberOfWheels} \n" +
            $"Moc silnika: {EnginePower} KM";
    }
}
