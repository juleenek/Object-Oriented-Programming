using Kserokopiarka.Zadanie3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace KserokopiarkaTestProject
{
    class Zadanie3UnitTests
    {
        [TestClass]
        public class UnitTestMultifunctionalDevice
        {
            [TestMethod]
            public void MultifunctionalDevice_GetState_StateOff()
            {
                var multifunctionalDevice = new MultifunctionalDevice();
                multifunctionalDevice.PowerOff();

                Assert.AreEqual(IDevice.State.off, multifunctionalDevice.GetState());
            }

            [TestMethod]
            public void MultifunctionalDevice_GetState_StateOn()
            {
                var multifunctionalDevice = new MultifunctionalDevice();
                multifunctionalDevice.PowerOn();

                Assert.AreEqual(IDevice.State.on, multifunctionalDevice.GetState());
            }


            // weryfikacja, czy po wywołaniu metody `Print` i włączonej kopiarce w napisie pojawia się słowo `Print`
            // wymagane przekierowanie konsoli do strumienia StringWriter
            [TestMethod]
            public void MultifunctionalDevice_SendFax_DeviceOn()
            {
                var multifunctionalDevice = new MultifunctionalDevice();
                multifunctionalDevice.PowerOn();

                var currentConsoleOut = Console.Out;
                currentConsoleOut.Flush();
                using (var consoleOutput = new ConsoleRedirectionToStringWriter())
                {
                    int faxNum = 123;
                    IDocument doc1 = new PDFDocument("aaa.pdf");
                    multifunctionalDevice.SendFax(out doc1, faxNum, IDocument.FormatType.PDF);
                    Assert.IsTrue(consoleOutput.GetOutput().Contains($"To: {faxNum} Fax: PDFScan"));
                }
                Assert.AreEqual(currentConsoleOut, Console.Out);
            }

            // weryfikacja, czy po wywołaniu metody `Print` i wyłączonej kopiarce w napisie NIE pojawia się słowo `Print`
            // wymagane przekierowanie konsoli do strumienia StringWriter
            [TestMethod]
            public void MultifunctionalDevice_SendFax_DeviceOff()
            {
                var multifunctionalDevice = new MultifunctionalDevice();
                multifunctionalDevice.PowerOff();

                var currentConsoleOut = Console.Out;
                currentConsoleOut.Flush();
                using (var consoleOutput = new ConsoleRedirectionToStringWriter())
                {
                    int faxNum = 123;
                    IDocument doc1 = new PDFDocument("aaa.pdf");
                    multifunctionalDevice.SendFax(out doc1, faxNum, IDocument.FormatType.PDF);
                    Assert.IsFalse(consoleOutput.GetOutput().Contains($"To: {faxNum} Fax: PDFScan"));
                }
                Assert.AreEqual(currentConsoleOut, Console.Out);
            }

            // weryfikacja, czy po wywołaniu metody `Scan` i wyłączonej kopiarce w napisie NIE pojawia się słowo `Scan`
            // wymagane przekierowanie konsoli do strumienia StringWriter
            [TestMethod]
            public void MultifunctionalDevice_ReceiveFax_DeviceOff()
            {
                var multifunctionalDevice = new MultifunctionalDevice();
                multifunctionalDevice.PowerOff();

                var currentConsoleOut = Console.Out;
                currentConsoleOut.Flush();
                using (var consoleOutput = new ConsoleRedirectionToStringWriter())
                {
                    int faxNum = 123;
                    IDocument doc1 = new PDFDocument("aaa.pdf");
                    multifunctionalDevice.SendFax(out doc1, faxNum, IDocument.FormatType.PDF);
                    multifunctionalDevice.ReceiveFax(faxNum);
                    Assert.IsFalse(consoleOutput.GetOutput().Contains($"For: {faxNum} File: PDFScan"));
                }
                Assert.AreEqual(currentConsoleOut, Console.Out);
            }

            // weryfikacja, czy po wywołaniu metody `Scan` i wyłączonej kopiarce w napisie pojawia się słowo `Scan`
            // wymagane przekierowanie konsoli do strumienia StringWriter
            [TestMethod]
            public void MultifunctionalDevice_ReceiveFax_DeviceOn()
            {
                var multifunctionalDevice = new MultifunctionalDevice();
                multifunctionalDevice.PowerOn();

                var currentConsoleOut = Console.Out;
                currentConsoleOut.Flush();
                using (var consoleOutput = new ConsoleRedirectionToStringWriter())
                {
                    int faxNum = 123;
                    IDocument doc1 = new PDFDocument("aaa.pdf");
                    multifunctionalDevice.SendFax(out doc1, faxNum, IDocument.FormatType.PDF);
                    multifunctionalDevice.ReceiveFax(faxNum);
                    Assert.IsTrue(consoleOutput.GetOutput().Contains($"For: {faxNum} File: PDFScan"));
                }
                Assert.AreEqual(currentConsoleOut, Console.Out);
            }

            [TestMethod]
            public void MultifunctionalDevice_FaxCounter()
            {
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

                // 4 faxów (3 wysłanych i 1 czynność odebrania), gdy urządzenie włączone
                Assert.AreEqual(4, multifunctionalDevice.FaxCounter);
            }

            [TestMethod]
            public void MultifunctionalDevice_FaxNumberCheck()
            {
                var multifunctionalDevice = new MultifunctionalDevice();
                multifunctionalDevice.PowerOn();

                var currentConsoleOut = Console.Out;
                currentConsoleOut.Flush();
                using (var consoleOutput = new ConsoleRedirectionToStringWriter())
                {
                    int faxNum = 123;
                    IDocument doc1 = new PDFDocument("aaa.pdf");
                    multifunctionalDevice.SendFax(out doc1, faxNum, IDocument.FormatType.PDF);
                    multifunctionalDevice.ReceiveFax(faxNum);
                    multifunctionalDevice.ReceiveFax(faxNum);
                    Assert.IsTrue(consoleOutput.GetOutput().Contains("You don't have any fax."));
                }
                Assert.AreEqual(currentConsoleOut, Console.Out);
            }

            [TestMethod]
            public void MultifunctionalDevice_PowerOnCounter()
            {
                var multifunctionalDevice = new MultifunctionalDevice();
                multifunctionalDevice.PowerOn();
                multifunctionalDevice.PowerOn();
                multifunctionalDevice.PowerOn();

                int faxNum = 123;
                IDocument doc1 = new PDFDocument("aaa.pdf");
                multifunctionalDevice.SendFax(out doc1, faxNum, IDocument.FormatType.PDF);
                IDocument doc2 = new TextDocument("aaa.txt");
                multifunctionalDevice.SendFax(out doc2, faxNum, IDocument.FormatType.TXT);

                multifunctionalDevice.PowerOff();
                multifunctionalDevice.PowerOff();
                multifunctionalDevice.PowerOff();
                multifunctionalDevice.PowerOn();

                IDocument doc3 = new ImageDocument("aaa.jpg");
                multifunctionalDevice.SendFax(out doc3, faxNum, IDocument.FormatType.JPG);

                multifunctionalDevice.PowerOff();
                multifunctionalDevice.ReceiveFax(faxNum);
                multifunctionalDevice.PowerOn();

                // 3 włączenia
                Assert.AreEqual(3, multifunctionalDevice.Counter);
            }
            // weryfikacja, czy po wywołaniu metody `Print` i włączonej kopiarce w napisie pojawia się słowo `Print`
            // oraz czy występuje komuniat związany z uruchomieniem konkretnie drukarki `Printer is on...`
            // wymagane przekierowanie konsoli do strumienia StringWriter
            [TestMethod]
            public void Copier_Printer_Message_DeviceOn()
            {
                var copier = new Copier();
                copier.PowerOn();

                var currentConsoleOut = Console.Out;
                currentConsoleOut.Flush();
                using (var consoleOutput = new ConsoleRedirectionToStringWriter())
                {
                    IDocument doc1 = new PDFDocument("aaa.pdf");
                    copier.Print(in doc1);
                    Assert.IsTrue(consoleOutput.GetOutput().Contains("Printer is on"));
                    Assert.IsTrue(consoleOutput.GetOutput().Contains("Print"));
                }
                Assert.AreEqual(currentConsoleOut, Console.Out);
            }
            // weryfikacja, czy po wywołaniu metody `Scan` i włączonej kopiarce w napisie pojawia się słowo `Scan`
            // oraz czy występuje komuniat związany z uruchomieniem konkretnie drukarki `Scanner is on...`
            // wymagane przekierowanie konsoli do strumienia StringWriter
            [TestMethod]
            public void Copier_Scanner_Message_DeviceOn()
            {
                var copier = new Copier();
                copier.PowerOn();

                var currentConsoleOut = Console.Out;
                currentConsoleOut.Flush();
                using (var consoleOutput = new ConsoleRedirectionToStringWriter())
                {
                    IDocument doc1 = new PDFDocument("aaa.pdf");
                    copier.Scan(out doc1, IDocument.FormatType.PDF);
                    Assert.IsTrue(consoleOutput.GetOutput().Contains("Scanner is on"));
                    Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                }
                Assert.AreEqual(currentConsoleOut, Console.Out);
            }
            // weryfikacja, czy po wywołaniu metody `ScanAndPrint` i włączonej kopiarce w napisie pojawia się słowo `Scan` oraz `Print`
            // oraz czy występuje komuniat związany z uruchomieniem konkretnie drukarki `Scanner is on...` oraz `Printer is on...`
            // wymagane przekierowanie konsoli do strumienia StringWriter
            [TestMethod]
            public void Copier_ScannerPrinter_Message_DeviceOn()
            {
                var copier = new Copier();
                copier.PowerOn();

                var currentConsoleOut = Console.Out;
                currentConsoleOut.Flush();
                using (var consoleOutput = new ConsoleRedirectionToStringWriter())
                {
                    copier.ScanAndPrint();
                    Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                    Assert.IsTrue(consoleOutput.GetOutput().Contains("Scanner is on"));
                    Assert.IsTrue(consoleOutput.GetOutput().Contains("Print"));
                    Assert.IsTrue(consoleOutput.GetOutput().Contains("Printer is on"));
                }
                Assert.AreEqual(currentConsoleOut, Console.Out);
            }
        }
    }
}
