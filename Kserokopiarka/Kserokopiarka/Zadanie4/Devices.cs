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
            if (GetState() != State.on)
            {
                GetState();
            }
            else
            {
                SetState(State.standby);
            }
        }
        void StandbyOff() // wyłącza oszczędzanie energii, ustawia State.on
        {
            if (GetState() != State.standby)
            {
                GetState();
            }
            else
            {
                SetState(State.on);
            }
        }

        State GetState(); // zwraca aktualny stan urządzenia
        abstract protected void SetState(State state); // ustawia stan oszczędzania energii

        int Counter { get; }  // zwraca liczbę charakteryzującą eksploatację urządzenia,
                              // np. liczbę uruchomień, liczbę wydrukow, liczbę skanów, ...
    }

    public abstract class BaseDevice : IDevice
    {
        protected IDevice.State state = IDevice.State.off;
        public IDevice.State GetState() => state;

        public void PowerOff()
        {
            state = IDevice.State.off;
            Console.WriteLine("... Device is off !");
        }

        public void PowerOn()
        {
            state = IDevice.State.on;
            Console.WriteLine("Device is on ...");
        }

        public int Counter { get; private set; } = 0;
    }

    public interface IPrinter : IDevice
    {
        /// <summary>
        /// Dokument jest drukowany, jeśli urządzenie włączone. W przeciwnym przypadku nic się nie wykonuje
        /// </summary>
        /// <param name="document">obiekt typu IDocument, różny od `null`</param>
        void Print(in IDocument document);
    }

    public interface IScanner : IDevice
    {
        // dokument jest skanowany, jeśli urządzenie włączone
        // w przeciwnym przypadku nic się dzieje
        void Scan(out IDocument document, IDocument.FormatType formatType);
    }
}
