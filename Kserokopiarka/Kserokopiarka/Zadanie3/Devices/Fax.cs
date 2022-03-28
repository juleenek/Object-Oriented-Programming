using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kserokopiarka.Zadanie3
{
    public class Fax : BaseDevice, IFax
    {
        public List<string[]> faxDocuments = new List<string[]>();
        public void PowerOnFax()
        {
            if (state == IDevice.State.on)
            {
                Console.WriteLine("Fax is already on.");
                return;
            }
            state = IDevice.State.on;
            Console.WriteLine("Fax is on ...");
        }
        public void PowerOffFax()
        {
            if (state == IDevice.State.off)
            {
                Console.WriteLine("Fax is already off.");
                return;
            }
            state = IDevice.State.off;
            Console.WriteLine("... Fax is off!");
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
                    anyFaxCounter++;
                }
            }
            if (anyFaxCounter == 0)
            {
                Console.WriteLine("You don't have any fax.");
            }
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
                string[] arr = { reciverFaxNumber.ToString(), fileName, DateTime.Now.ToString() };
                faxDocuments.Add(arr);
                Console.WriteLine($"{DateTime.Now} To: {reciverFaxNumber} Fax: {fileName}");
                return;

            }
            else
            {
                fileName = $"TextScan{Counter}.txt";
                document = new TextDocument(fileName);
                string[] arr = { reciverFaxNumber.ToString(), fileName, DateTime.Now.ToString() };
                faxDocuments.Add(arr);
                Console.WriteLine($"{DateTime.Now} To: {reciverFaxNumber} Fax: {fileName}");
                return;

            };
        }
    }
}
