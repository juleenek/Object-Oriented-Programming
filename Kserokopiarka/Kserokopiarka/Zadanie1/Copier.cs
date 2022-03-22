using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kserokopiarka.Zadanie1
{
    public class Copier : BaseDevice, IPrinter, IScanner{

        public int PrintCounter { get; set; } = 0;
        public int ScanCounter { get; set; } = 0;
        public new int Counter { get; set; } = 0;

        public void Print(in IDocument document)
        {
            if (state == IDevice.State.off)
                return; // Do nothing

            Console.WriteLine($"{DateTime.Now} Print: {document.GetFileName()}");
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            document = null;
            if (state == IDevice.State.off)
            {
                document = null;
                return; // Do nothing
            }

            if (formatType == IDocument.FormatType.PDF)
            {
                Console.WriteLine($"{DateTime.Now} Scan: PDFScan{Counter}.pdf");
            } else if (formatType == IDocument.FormatType.JPG)
            {
                Console.WriteLine($"{DateTime.Now} Scan: ImageScan{Counter}.jpg");
            }else if(formatType == IDocument.FormatType.TXT)
            {
                Console.WriteLine($"{DateTime.Now} Scan: TextScan{Counter}.txt");
            };
        }
        public void Scan(out IDocument document)
        {
            throw new NotImplementedException();
        }

        public new void PowerOn()
        {
            if (state == IDevice.State.on)
            {
                return; // Do nothing
            }
            state = IDevice.State.on;
            Console.WriteLine("Device is on ...");
        }
        public new void PowerOff()
        {
            if (state == IDevice.State.off)
            {
                return; // Do nothing
            }
            state = IDevice.State.off;
            Console.WriteLine("... Device is off !");
        }

        public void ScanAndPrint()
        {
            throw new NotImplementedException();
        }
    }
}
