using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kserokopiarka.Zadanie3
{
    public class Copier : BaseDevice
    {
        private Printer Printer { get; }
        private Scanner Scanner { get; }
        public new int Counter { get; set; }
        public int ScanCounter { get; set; }
        public int PrintCounter { get; set; }
        public Copier()
        {
            Printer = new Printer();
            Scanner = new Scanner();
        }
        public new void PowerOn()
        {
            if (state == IDevice.State.on)
            {
                Console.WriteLine("Device is already on.");
                return;
            }
            Counter++;
            state = IDevice.State.on;
            Console.WriteLine("Device is on ...");
        }
        public new void PowerOff()
        {
            if (state == IDevice.State.off)
            {
                Console.WriteLine("Device is already off.");
                return;
            }
            state = IDevice.State.off;
            Console.WriteLine("... Device is off!");
        }
     
        public void Print(in IDocument document)
        {
            if (state == IDevice.State.off)
            {
                Console.WriteLine("You need to turn on the device.");
                return;
            }
            Printer.PowerOnPrinter();
            Printer.Print(document);
            PrintCounter++;
            Printer.PowerOffPrinter();
        }
        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            if (state == IDevice.State.off)
            {
                Console.WriteLine("You need to turn on the device.");
                document = null;
                return;
            }
            Scanner.PowerOnScanner();
            Scanner.Scan(out document, formatType);
            ScanCounter++;
            Scanner.PowerOffScanner();
        }
        public void ScanAndPrint()
        {
            if (state == IDevice.State.off)
            {
                Console.WriteLine("You need to turn on the device.");
                return;
            }
            Scan(out IDocument document);
            Print(in document);
        }
    }
}
