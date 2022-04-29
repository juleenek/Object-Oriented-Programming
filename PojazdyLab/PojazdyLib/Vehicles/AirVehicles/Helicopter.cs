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
        public new double MaxSpeed => 160;
        public new double LandingRisingBoundary => 20.0;
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
    }
}
