using System;
using System.Collections.Generic;
using System.IO;
using TempElementsLib.src;
using TempElementsLib.src.Interfaces;

namespace TempElementsLib
{
    public class TempElementsList : ITempElements
    {
        private bool disposed;
        private readonly List<ITempElement> elements = new List<ITempElement>();

        public IReadOnlyCollection<ITempElement> Elements => elements;

        ~TempElementsList() => Dispose();

        public T AddElement<T>() where T : ITempElement, new()
        {
            T element = new T();
            elements.Add(element);
            return element;
        }

        public void DeleteElement<T>(T element) where T : ITempElement, new()
        {
            element.Dispose();
        }

        public void MoveElementTo<T>(T element, string newPath) where T : ITempElement, new()
        {
            switch (element)
            {
                case TempDir tempDir:
                    {  
                        DirectoryInfo dirInfo = new DirectoryInfo(tempDir.DirPath);
                        if (dirInfo.Exists) Directory.Move(dirInfo.FullName, newPath);
                        break;
                    }
                case TempFile tempFile:
                    {
                        FileInfo fileInfo = new FileInfo(tempFile.FilePath);
                        if (fileInfo.Exists) File.Move(fileInfo.FullName, newPath);
                        break;
                    }
            }
        }

        public void RemoveDestroyed()
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].IsDestroyed) {
                    elements.Remove(elements[i]);
                    elements[i].Dispose();
                }
            }
        }

        public bool IsEmpty => ((ITempElements)this).IsEmpty;


        #region Dispose section ==============================================
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    for (int i = 0; i < elements.Count; i++)
                    {
                        elements[i].Dispose();
                    }
                }

                disposed = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~TempDirsAndFolders()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
