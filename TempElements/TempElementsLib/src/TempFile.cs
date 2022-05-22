using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempElementsLib.src.Interfaces;

namespace TempElementsLib.src
{
    public class TempFile : ITempFile
    {
        public readonly FileStream fileStream;
        public readonly FileInfo fileInfo;
        public bool IsDestroyed => !fileInfo.Exists;
        public string FilePath => fileInfo.FullName;

        public TempFile() : this(Path.GetTempFileName()) { }
        public TempFile(string fileName)
        {
            fileInfo = new FileInfo(fileName);
            fileStream = new FileStream(
                FilePath, FileMode.OpenOrCreate,
                FileAccess.ReadWrite);
            Console.WriteLine($"File {FilePath} created");
        }

        ~TempFile() => Dispose(false);  // Destructor

        public void AddText(string text)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(text);
            fileStream.Write(info, 0, info.Length);
            fileStream.Flush();
        }

        public void Dispose()
        {
            Dispose(true);
        }
        public void Dispose(bool disposing)
        {
            if (disposing)
                fileStream?.Dispose();
            try
            {
                fileInfo?.Delete();
                Console.WriteLine($"File disposed");
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
