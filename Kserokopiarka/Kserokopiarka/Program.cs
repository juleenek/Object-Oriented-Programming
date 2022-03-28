using Kserokopiarka.Zadanie3;
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
            ///////////////// using Kserokopiarka.Zadanie1 /////////////////


            //var xerox = new Copier();
            //xerox.PowerOn();
            //IDocument doc1 = new PDFDocument("aaa.pdf");
            //xerox.Print(in doc1);

            //IDocument doc2;
            //xerox.Scan(out doc2);

            //xerox.ScanAndPrint();
            //Console.WriteLine(xerox.Counter);
            //Console.WriteLine(xerox.PrintCounter);
            //Console.WriteLine(xerox.ScanCounter);


            ///////////////// using Kserokopiarka.Zadanie2 /////////////////


            //var multifunctionalDevice = new MultifunctionalDevice();
            //multifunctionalDevice.PowerOn();
            //int faxNum = 123;

            //IDocument doc1 = new PDFDocument("aaa.pdf");
            //multifunctionalDevice.SendFax(out doc1, faxNum, IDocument.FormatType.PDF);
            //IDocument doc2 = new TextDocument("aaa.txt");
            //multifunctionalDevice.SendFax(out doc2, faxNum, IDocument.FormatType.TXT);
            //IDocument doc3 = new ImageDocument("aaa.jpg");
            //multifunctionalDevice.SendFax(out doc3, faxNum, IDocument.FormatType.JPG);


            //multifunctionalDevice.PowerOff();
            //multifunctionalDevice.ReceiveFax(faxNum);
            //multifunctionalDevice.SendFax(out doc1, faxNum, IDocument.FormatType.PDF);
            //multifunctionalDevice.PowerOn();

            //multifunctionalDevice.ReceiveFax(faxNum);

            //Console.WriteLine(multifunctionalDevice.FaxCounter);


            ///////////////// using Kserokopiarka.Zadanie3 /////////////////

            ////// Copier //////

            //var xerox = new Copier();
            //xerox.PowerOn();
            //IDocument doc1 = new PDFDocument("aaa.pdf");
            //xerox.Print(in doc1);

            //IDocument doc2;
            //xerox.Scan(out doc2);

            //xerox.ScanAndPrint();
            //Console.WriteLine(xerox.Counter);
            //Console.WriteLine(xerox.PrintCounter);
            //Console.WriteLine(xerox.ScanCounter);


            ////// MultifunctionalDevice //////

            //var multifunctionalDevice = new MultifunctionalDevice();
            //multifunctionalDevice.PowerOn();
            //int faxNum = 123;

            //IDocument doc1 = new PDFDocument("aaa.pdf");
            //multifunctionalDevice.SendFax(out doc1, faxNum, IDocument.FormatType.PDF);
            //IDocument doc2 = new TextDocument("aaa.txt");
            //multifunctionalDevice.SendFax(out doc2, faxNum, IDocument.FormatType.TXT);
            //IDocument doc3 = new ImageDocument("aaa.jpg");
            //multifunctionalDevice.SendFax(out doc3, faxNum, IDocument.FormatType.JPG);


            //multifunctionalDevice.PowerOff();
            //multifunctionalDevice.ReceiveFax(faxNum);
            //multifunctionalDevice.SendFax(out doc1, faxNum, IDocument.FormatType.PDF);
            //multifunctionalDevice.PowerOn();

            //multifunctionalDevice.ReceiveFax(faxNum);

            //Console.WriteLine(multifunctionalDevice.FaxCounter);

            var copier = new Copier();
            copier.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            
                IDocument doc1 = new PDFDocument("aaa.pdf");
                copier.Print(in doc1);
              
            
        }
    }
}
