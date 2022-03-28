using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kserokopiarka.Zadanie3
{
    public class Scanner : BaseDevice, IScanner
    {
        public void PowerOnScanner()
        {
            if (state == IDevice.State.on)
            {
                Console.WriteLine("Scanner is already on.");
                return;
            }
            state = IDevice.State.on;
            Console.WriteLine("Scanner is on ...");
        }
        public void PowerOffScanner()
        {
            if (state == IDevice.State.off)
            {
                Console.WriteLine("Scanner is already off.");
                return;
            }
            state = IDevice.State.off;
            Console.WriteLine("... Scanner is off!");
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

            if (formatType == IDocument.FormatType.PDF)
            {
                fileName = $"PDFScan{Counter }.pdf";
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
    }
}
