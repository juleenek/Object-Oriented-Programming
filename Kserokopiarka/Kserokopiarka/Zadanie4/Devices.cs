using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kserokopiarka.Zadanie4
{
    public interface IDevice
    {
        enum State { on, off, standby };

        void PowerOn() // uruchamia urządzenie, zmienia stan na `on`
        { 
            SetState(State.on);
        }
        void PowerOff() // wyłącza urządzenie, zmienia stan na `off
        {
            SetState(State.off);
        }
        void StandbyOn() // uruchamia oszczędzanie energii gdy urządzenie jest włączone 
        {
                SetState(State.standby);   
        }
        void StandbyOff() // wyłącza oszczędzanie energii, ustawia State.on
        {
                SetState(State.on);
        }

        State GetState(); // zwraca aktualny stan urządzenia
        abstract protected void SetState(State state); // ustawia stan oszczędzania energii

        int Counter { get; }  // zwraca liczbę charakteryzującą eksploatację urządzenia,
                              // np. liczbę uruchomień, liczbę wydrukow, liczbę skanów, ...
    }

    public interface IPrinter : IDevice
    {
        /// <summary>
        /// Dokument jest drukowany, jeśli urządzenie włączone. W przeciwnym przypadku nic się nie wykonuje
        /// </summary>
        /// <param name="document">obiekt typu IDocument, różny od `null`</param>
        void Print(in IDocument document);
        new void SetState(State state);
    }

    public interface IScanner : IDevice
    {
        // dokument jest skanowany, jeśli urządzenie włączone
        // w przeciwnym przypadku nic się dzieje
        void Scan(out IDocument document, IDocument.FormatType formatType);
        new void SetState(State state);
    }
}
