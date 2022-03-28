using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kserokopiarka.Zadanie3
{
    public class MultifunctionalDevice : Copier
    {
        private Fax Fax { get; }
        private Printer Printer { get; }
        private Scanner Scanner { get; }
        public int FaxCounter { get; set; }
        public MultifunctionalDevice()
        {
            Printer = new Printer();
            Scanner = new Scanner();
            Fax = new Fax();
        }
        public void SendFax(out IDocument document, int reciverFaxNumber, IDocument.FormatType formatType = IDocument.FormatType.PDF)
        {
            if (state == IDevice.State.off)
            {
                Console.WriteLine("You need to turn on the device.");
                document = null;
                return;
            }
            Fax.PowerOnFax();
            Fax.SendFax(out document, reciverFaxNumber, formatType);
            FaxCounter++;
            Fax.PowerOffFax();
        }

        public void ReceiveFax(int faxNumber)
        {
            if (state == IDevice.State.off)
            {
                Console.WriteLine("You need to turn on the device.");
                return;
            }
            Fax.PowerOnFax();
            FaxCounter++;
            Fax.ReceiveFax(faxNumber);
            Fax.PowerOffFax();
        }
    }
}
