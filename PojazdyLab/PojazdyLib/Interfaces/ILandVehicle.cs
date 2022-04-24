using PojazdyLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojazdyLib.Interfejsy
{
    interface ILandVehicle : IBase
    {
        byte NumberOfWheels { get; } // Liczba kół pojazdu
    }
}
