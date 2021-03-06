using PojazdyLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojazdyLib.Interfejsy
{
    interface IAirVehicle : IBase
    {
       double LandingRisingBoundary { get; }
       bool IsInTheAir { get; }
       void Land();
       void RiseUp();
    }
}
