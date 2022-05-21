﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempElementsLib.src
{
    public class TempTxtFile : TempFile
    {
        private TextReader txtReader;
        private TextWriter txtWriter;

        public TempTxtFile(string fileName) : base(fileName)
        {
            // Implementuje element TextReader, który odczytuje znaki ze strumienia bajtów w określonym kodowaniu.
            txtReader = new StreamReader(fileStream, Encoding.UTF8);
            // Implementuje element TextWriter do zapisywania znaków w strumieniu w określonym kodowaniu.
            txtWriter = new StreamWriter(fileStream);
        }
        public void Write(string text)
        {
            txtWriter.Write(text);
            // Czyści bufory dla tego strumienia i powodują zapisanie wszystkich buforowanych danych do pliku.
            txtWriter.Flush();
        }
        public void WriteLine(string text)
        {
            txtWriter.WriteLine(text);
            txtWriter.Flush();
        }
        public void ReadAllText()
        {
            txtReader.ReadToEnd();
        }
        public void Read()
        {
            txtReader.ReadLine();
        }
    }
}
