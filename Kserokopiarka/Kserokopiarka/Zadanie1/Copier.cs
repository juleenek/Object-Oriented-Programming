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
            if (state == IDevice.State.off)
            {
                document = null;
                return; // Do nothing
            }

            string fileName;
            DateTime date = new DateTime();

            if (formatType == IDocument.FormatType.PDF)
            {
               fileName = $"PDFScan{Counter + 1}.pdf";
               document = new PDFDocument(fileName);
               Console.WriteLine($"{date} Scan: {fileName}");
                return;

            } else if (formatType == IDocument.FormatType.JPG)
            {
                fileName = $"ImageScan{Counter + 1}.jpg";
                document = new ImageDocument(fileName);
                Console.WriteLine($"{date} Scan: {fileName}");
                return;
            }else
            {
                fileName = $"TextScan{Counter+ 1}.txt";
                document = new TextDocument(fileName);
                Console.WriteLine($"{date} Scan: {fileName}");
                return;
            };
        }
        public void Scan(out IDocument document)
        {
            if (state == IDevice.State.off)
            {
                document = null;
                return; // Do nothing
            }
        
            IDocument.FormatType formatType = IDocument.FormatType.JPG;
            Scan(out document, formatType);
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
            if (state == IDevice.State.off)
            {
                return; // Do nothing
            }

            Scan(out IDocument document);
            Print(in document);
            
        }
    }
}
