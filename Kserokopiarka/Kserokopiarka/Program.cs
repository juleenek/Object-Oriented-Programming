using Kserokopiarka.Zadanie2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kserokopiarka
{
    class Program
    {
        static void Main()
        {
            //var xerox = new Copier();
            //xerox.PowerOn();
            //IDocument doc1 = new PDFDocument("aaa.pdf");
            //xerox.Print(in doc1);

            //IDocument doc2;
            //xerox.Scan(out doc2);

            //xerox.ScanAndPrint();
            //System.Console.WriteLine(xerox.Counter);
            //System.Console.WriteLine(xerox.PrintCounter);
            //System.Console.WriteLine(xerox.ScanCounter);

            var multifunctionalDevice = new MultifunctionalDevice();
            multifunctionalDevice.PowerOn();
            int faxNum = 123;

            IDocument doc1 = new PDFDocument("aaa.pdf");
            multifunctionalDevice.SendFax(out doc1, faxNum, IDocument.FormatType.PDF);
            IDocument doc2 = new TextDocument("aaa.txt");
            multifunctionalDevice.SendFax(out doc2, faxNum, IDocument.FormatType.TXT);
            IDocument doc3 = new ImageDocument("aaa.jpg");
            multifunctionalDevice.SendFax(out doc3, faxNum, IDocument.FormatType.JPG);


            multifunctionalDevice.PowerOff();
            multifunctionalDevice.ReceiveFax(faxNum);
            multifunctionalDevice.SendFax(out doc1, faxNum, IDocument.FormatType.PDF);
            multifunctionalDevice.PowerOn();

            multifunctionalDevice.ReceiveFax(faxNum);

            Console.WriteLine(multifunctionalDevice.FaxCounter);

        }
    }
}
