using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempElementsLib.src.Interfaces;

namespace TempElementsLib.src
{
    public class TempDir : ITempDir
    {
        public DirectoryInfo dirInfo;
        public string DirPath => dirInfo.FullName;
        public bool IsEmpty => (dirInfo.GetDirectories().Length == 0 && dirInfo.GetFiles().Length == 0);
        public bool IsDestroyed => !dirInfo.Exists;
        public TempDir() : this(Guid.NewGuid().ToString())
        { }
        public TempDir(string fileName) 
        {
            dirInfo = new DirectoryInfo(fileName);
            Directory.CreateDirectory(dirInfo.FullName);
            Console.WriteLine($"Directory created. Directory path: {DirPath}");
        }
        ~TempDir() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
        }
        public void Dispose(bool disposing)
        {
            try
            {
                dirInfo?.Delete();
                Console.WriteLine($"Directory disposed");
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception);
            }
        }

        public void Empty()
        {
            if(!IsEmpty)
            {
                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    file.Delete();
                }
            }
        }
    }
}
