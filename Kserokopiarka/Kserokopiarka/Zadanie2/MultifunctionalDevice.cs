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
        // FaxCounter - zlicza ile razy został użyty Fax 
        public int FaxCounter { get; set; }
        public new int Counter { get; set; }
        public List<string[]> faxDocuments = new List<string[]>();

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
            ScanCounter++;

            if (formatType == IDocument.FormatType.PDF)
            {
                fileName = $"PDFScan{Counter}.pdf";
                document = new PDFDocument(fileName);
                Console.WriteLine($"{DateTime.Now} Scan: {fileName}");
                return;

            }
            else if (formatType == IDocument.FormatType.JPG)
            {
                fileName = $"ImageScan{Counter}.jpg";
                document = new ImageDocument(fileName);
                Console.WriteLine($"{DateTime.Now} Scan: {fileName}");
                return;

            }
            else
            {
                fileName = $"TextScan{Counter}.txt";
                document = new TextDocument(fileName);
                Console.WriteLine($"{DateTime.Now} Scan: {fileName}");
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
            FaxCounter++;

            if (formatType == IDocument.FormatType.PDF)
            {
                fileName = $"PDFScan{Counter}.pdf";
                document = new PDFDocument(fileName);
                string[] arr = { reciverFaxNumber.ToString(), fileName, DateTime.Now.ToString() };
                faxDocuments.Add(arr);
                Console.WriteLine($"{DateTime.Now} To: {reciverFaxNumber} Fax: {fileName}");
                return;

            }
            else if (formatType == IDocument.FormatType.JPG)
            {
                fileName = $"ImageScan{Counter}.jpg";
                document = new ImageDocument(fileName);
                string[] arr = { reciverFaxNumber.ToString(), fileName, DateTime.Now.ToString()};
                faxDocuments.Add(arr);
                Console.WriteLine($"{DateTime.Now} To: {reciverFaxNumber} Fax: {fileName}");
                return;

            }
            else
            {
                fileName = $"TextScan{Counter}.txt";
                document = new TextDocument(fileName);
                string[] arr = { reciverFaxNumber.ToString(), fileName, DateTime.Now.ToString()};
                faxDocuments.Add(arr);
                Console.WriteLine($"{DateTime.Now} To: {reciverFaxNumber} Fax: {fileName}");
                return;

            };
        }

        public void ReceiveFax(int faxNumber)
        {
            if (state == IDevice.State.off)
            {
                Console.WriteLine("You need to turn on the device.");
                return;
            }
            int anyFaxCounter = 0;
            foreach (var faxItem in faxDocuments.ToList())
            {
                if (faxItem[0] == faxNumber.ToString())
                {
                    Console.WriteLine($"At: {faxItem[2]} For: {faxItem[0]} File: {faxItem[1]}");
                    faxDocuments.Remove(faxItem);
                    FaxCounter++;
                    anyFaxCounter++;
                }
            }
            if (anyFaxCounter == 0)
            {
                Console.WriteLine("You don't have any fax.");
            }
        }
    }
}
