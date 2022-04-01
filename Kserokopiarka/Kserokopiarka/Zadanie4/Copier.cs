using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Kserokopiarka.Zadanie4
{
    public class Copier : IPrinter, IScanner
    {
        private IPrinter printer;
        private IScanner scanner;
        private IDevice.State printerState = IDevice.State.off;
        private IDevice.State scannerState = IDevice.State.off;
        public int Counter { get; set; } = 0;
        public Copier()
        {
            printer = this;
            scanner = this;
        }

        public IDevice.State GetState()
        {
            throw new NotImplementedException();
        }

        public void Print(in IDocument document)
        {
            throw new NotImplementedException();
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            throw new NotImplementedException();
        }
        void IDevice.SetState(IDevice.State state)
        {
            throw new NotImplementedException();
        }

        void IPrinter.SetState(IDevice.State state)
        {
            throw new NotImplementedException();
        }

        void IScanner.SetState(IDevice.State state)
        {
            throw new NotImplementedException();
        }

    }
}
