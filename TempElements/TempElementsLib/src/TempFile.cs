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
        public TempFile(string fileName)
        {
            fileInfo = new FileInfo(fileName);
            fileStream = new FileStream(
                FilePath, FileMode.OpenOrCreate,
                FileAccess.ReadWrite);
            Console.WriteLine($"File {FilePath} created");
        }

        public void AddText(string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fileStream.Write(info, 0, info.Length);
            fileStream.Flush();
        }

        public void Dispose()
        {
            if (!IsDestroyed) fileStream.Dispose();
            if (!IsDestroyed) fileInfo.Delete();

            Console.WriteLine($"File disposed");
        }
    }
}
