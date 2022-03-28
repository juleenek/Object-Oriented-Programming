using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kserokopiarka.Zadanie3
{
    public class Printer : BaseDevice, IPrinter
    {
        public void PowerOnPrinter()
        {
            if (state == IDevice.State.on)
            {
                Console.WriteLine("Printer is already on.");
                return;
            }
            state = IDevice.State.on;
            Console.WriteLine("Printer is on ...");
        }
        public void PowerOffPrinter()
        {
            if (state == IDevice.State.off)
            {
                Console.WriteLine("Printer is already off.");
                return;
            }
            state = IDevice.State.off;
            Console.WriteLine("... Printer is off!");
        }
        public void Print(in IDocument document)
        {
            if (state == IDevice.State.off)
            {
                Console.WriteLine("You need to turn on the device.");
                return;
            }
            Console.WriteLine($"{DateTime.Now} Print: {document.GetFileName()}");
        }
    }
}
