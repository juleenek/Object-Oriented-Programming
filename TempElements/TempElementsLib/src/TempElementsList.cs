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
            elements.Remove(element);
            element.Dispose();
        }

        public void MoveElementTo<T>(T element, string newPath) where T : ITempElement, new()
        {
            // ...
        }

        public void RemoveDestroyed()
            => throw new NotImplementedException();

        public bool IsEmpty => ((ITempElements)this).IsEmpty;


        #region Dispose section ==============================================
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
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
