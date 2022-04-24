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
        int MinSpeed { get; }
        int MaxSpeed { get; }
        SpeedUnit Unit { get; }
       bool HasAnEngine { get; } // Czy pojazd ma silnik?
        FuelType FuelType { get; } // Typ paliwa
        int EnginePower { get; } // Moc silnika
        
    }
}
