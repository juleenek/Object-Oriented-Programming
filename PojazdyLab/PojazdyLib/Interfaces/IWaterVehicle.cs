using PojazdyLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojazdyLib.Interfejsy
{
    interface IWaterVehicle : IBase
    {
        int Displacement { get; } // Wyporność pojazdu wodnego
    }
}
