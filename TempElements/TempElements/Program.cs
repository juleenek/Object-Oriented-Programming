using System;
using System.IO;
using TempElementsLib.src;

namespace TempElements
{
    class Program
    {
        static void Zadanie1_TempFile()
        {
            using (var tmpFile = new TempFile("ccc.tmp"))
            {
                // Use temporary file stream ...
                tmpFile.AddText("\\test");
                tmpFile.fileStream.WriteByte(63);
            }
            // tmpFile is out of scope, resources disposed

            // Correct, but not recommended
            var tmpFile2 = new TempFile("ccc.tmp");
            // Use temporary file stream ...
            tmpFile2.Dispose();

            //tmpFile2.AddText("\\test");
            tmpFile2.fileStream.WriteByte(63);
        }

        static void Zadanie1_Try_TempFile()
        {
            TempFile tmpFile = new TempFile("ccc.tmp");
            try
            {
                tmpFile.AddText("\\test");
                tmpFile.fileStream.WriteByte(63);
                tmpFile.Dispose();
                tmpFile.AddText("\\test"); // An exception will be thrown
            }
            catch (ObjectDisposedException exception)
            {
                Console.WriteLine($"{exception.Message} Zgłoszony wyjątek, nie można uzyskać dostępu do usuniętego pliku");
            }
        }
        static void Zadanie2_TempTxtFile()
        {
            using (TempTxtFile tmpTxtFile = new TempTxtFile("ccc.tmp"))
            {
                tmpTxtFile.Write("Test12");
                tmpTxtFile.WriteLine("3");
                tmpTxtFile.Write("Test4");
                tmpTxtFile.WriteLine("56");
                tmpTxtFile.Write("Test");
                tmpTxtFile.WriteLine("789");

                Console.WriteLine("-------");
                tmpTxtFile.ReadLine();
                tmpTxtFile.ReadLine();
                tmpTxtFile.ReadLine();
                Console.WriteLine("-------");
                tmpTxtFile.ReadAllText();
        
            }
        }
        static void Main(string[] args)
        {
            //Zadanie1_TempFile();
            //Zadanie1_Try_TempFile();
            Zadanie2_TempTxtFile();
        }
    }
}
 