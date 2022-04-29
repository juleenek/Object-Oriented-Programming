using PojazdyLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PojazdyLib.Interfejsy
{
    public interface IVehicle
    {
        enum State { off, on } // Stan pojazdu - czy pojazd jest uruchomiony czy zatrzymany
        double CurrentSpeed { get; } // Aktualna prędkość pojazdu
        bool? CanVahicleBeStopped { get; } // Czy można zatrzymać pojazd? 
        void Start(); // Uruchamia pojazd
        void Stop(); // Zatrzymuje pojazd
        void IncreaseSpeed(double speed); // Zwiększa prędkość pojazdu
        void ReduceSpeed(double speed); // Zmniejsza prędkość pojazdu
    }
}
