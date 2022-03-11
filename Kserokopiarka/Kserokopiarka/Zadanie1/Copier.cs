using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kserokopiarka.Zadanie1
{
    public class Copier : BaseDevice, IPrinter, IScanner{

        public int PrintCounter { get; set; }
        public int ScanCounter { get; set; }
        public new int Counter { get; set; }

        public void Print(in IDocument document)
        {
            throw new NotImplementedException();
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            throw new NotImplementedException();
        }
    }
}
