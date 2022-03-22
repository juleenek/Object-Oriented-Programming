using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kserokopiarka.Zadanie2
{
    public class MultifunctionalDevice : BaseDevice, IPrinter, IScanner, IFax
    {
        public int PrintCounter { get; set; }
        public int ScanCounter { get; set; }
        public int FaxCounter { get; set; }
        public new int Counter { get; set; }
        public Dictionary<int, string> faxDocuments = new Dictionary<int, string>();

        public void Print(in IDocument document)
        {
            if (state == IDevice.State.off)
            {
                Console.WriteLine("You need to turn on the device.");
                return;
            }

            Console.WriteLine($"{DateTime.Now} Print: {document.GetFileName()}");
            PrintCounter++;
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            if (state == IDevice.State.off)
            {
                Console.WriteLine("You need to turn on the device.");
                document = null;
                return;
            }

            string fileName;
            DateTime date = new DateTime();
            ScanCounter++;

            if (formatType == IDocument.FormatType.PDF)
            {
                fileName = $"PDFScan{Counter + 1}.pdf";
                document = new PDFDocument(fileName);
                Console.WriteLine($"{date} Scan: {fileName}");
                return;

            }
            else if (formatType == IDocument.FormatType.JPG)
            {
                fileName = $"ImageScan{Counter + 1}.jpg";
                document = new ImageDocument(fileName);
                Console.WriteLine($"{date} Scan: {fileName}");
                return;

            }
            else
            {
                fileName = $"TextScan{Counter + 1}.txt";
                document = new TextDocument(fileName);
                Console.WriteLine($"{date} Scan: {fileName}");
                return;

            };
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

        public void SendFax(out IDocument document, int reciverFaxNumber, IDocument.FormatType formatType = IDocument.FormatType.PDF)
        {
            if (state == IDevice.State.off)
            {
                Console.WriteLine("You need to turn on the device.");
                document = null;
                return;
            }

            string fileName;
            DateTime date = new DateTime();
            FaxCounter++;

            if (formatType == IDocument.FormatType.PDF)
            {
                fileName = $"PDFScan{Counter + 1}.pdf";
                document = new PDFDocument(fileName);
                Console.WriteLine($"{date} To: {reciverFaxNumber} Fax: {fileName}");
                return;

            }
            else if (formatType == IDocument.FormatType.JPG)
            {
                fileName = $"ImageScan{Counter + 1}.jpg";
                document = new ImageDocument(fileName);
                Console.WriteLine($"{date} To: {reciverFaxNumber} Fax: {fileName}");
                return;

            }
            else
            {
                fileName = $"TextScan{Counter + 1}.txt";
                document = new TextDocument(fileName);
                Console.WriteLine($"{date} To: {reciverFaxNumber} Fax: {fileName}");
                return;

            };
        }

        public void ReceiveFax(in IDocument document, int faxNumber)
        {
            throw new NotImplementedException();
        }
    }
}
