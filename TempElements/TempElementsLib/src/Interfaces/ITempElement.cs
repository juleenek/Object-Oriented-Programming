using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempElementsLib.src.Interfaces
{
    /// <summary>
    /// Reprezentuje element o charakterze tymczasowym, usuwany wtedy, gdy przestaje być potrzebny (`Dispose`)
    /// </summary>
    public interface ITempElement : IDisposable
    {
        bool IsDestroyed { get; } //true, jeśli element skutecznie usunięty
    }
}
