﻿using System;
using TempElementsLib.src;

namespace TempElements
{
    class Program
    {
        static void Zadanie1()
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

        static void Zadanie1_Try()
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
        static void Main(string[] args)
        {
            Zadanie1();
            Zadanie1_Try();
        }
    }
}
 