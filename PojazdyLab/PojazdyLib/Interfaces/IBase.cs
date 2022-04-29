using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PojazdyLib.Enums;

namespace PojazdyLib.Interfaces
{
    interface IBase
    {
        string VehicleType { get; }
        double MinSpeed { get; }
        double MaxSpeed { get; }
        //string VehicleType { get; }
        SpeedUnit Unit { get; }
        bool HasAnEngine { get; } // Czy pojazd ma silnik?
        FuelType FuelType { get; } // Typ paliwa
        int EnginePower { get; } // Moc silnika
        
    }
}
